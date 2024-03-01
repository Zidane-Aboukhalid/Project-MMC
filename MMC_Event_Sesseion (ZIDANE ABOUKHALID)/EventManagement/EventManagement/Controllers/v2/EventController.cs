using Application.CustomActionFilters;
using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace EventManagement.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EventController(IEventRepository eventRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
        }

      
        [HttpGet]
        
        public async Task<IActionResult> GetAllwithoutsessions()
        {
            var events = await eventRepository.GetAllAsync();

            return Ok(mapper.Map<List<EventDto>>(events));
        }

        [HttpGet]
        [Route("thisweek", Name = "GetEventOfThisWeek")]
        public async Task<IActionResult> GetEventOfThisWeek()
        {
            var events = await eventRepository.GetEventOfThisWeek();

            return Ok(mapper.Map<List<EventDto>>(events));
        }




        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var events = await eventRepository.GetByIdAsync(id);

            if(events == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<EventDto>(events));

        }

      

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromForm] AddEventDto eventDto)
        {
            

            var events = mapper.Map<Event>(eventDto);
            events.Id=Guid.NewGuid();
            var ImagName = $"Img_Ev_{events.Id}";
            var ImagExten= Path.GetExtension(eventDto.file.FileName);
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

            
                var localeFilePath = Path.Combine(
                    webHostEnvironment.ContentRootPath,
                    "wwwroot/Upload/", $"{ImagName}{ImagExten}"
                    );
                var stream= new FileStream(localeFilePath, FileMode.Create);
                await eventDto.file.CopyToAsync(stream);
                events.URL = $"{hosturl}/Upload/{ImagName}{ImagExten}";
            events = await eventRepository.CreateAsync(events);
            var eventdto = mapper.Map<EventDto>(events);

            return Ok(eventdto);
          

        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromForm] AddEventDto eventDto)
        {
           // UploadImagValidation(eventDto.file);

            var events = await eventRepository.GetByIdAsync(id);
            var ImagName = $"Img_Ev_{id}";
            var ImagExten = Path.GetExtension(eventDto.file.FileName);
            string hosturl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
           
            if (events != null)
            {
                // Supprimer l'ancienne image
                Uri uri = new Uri(events.URL);
                var OldImagExten = Path.GetExtension(uri.LocalPath);
                var oldImagePath = Path.Combine(
                       webHostEnvironment.ContentRootPath,
                       "wwwroot/Upload/", $"{ImagName}{OldImagExten}"
                   );
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                // Enregistrer la nouvelle image
                var localeFilePath = Path.Combine(
                    webHostEnvironment.ContentRootPath,
                    "wwwroot/Upload", $"{ImagName}{ImagExten}"
                );

                var stream = new FileStream(localeFilePath, FileMode.Create);
                await eventDto.file.CopyToAsync(stream);
                events.URL = $"{hosturl}/Upload/{ImagName}{ImagExten}";

                // Mettre à jour les autres propriétés de l'événement
                mapper.Map(eventDto, events);
                await eventRepository.UpdateAsync(events);

                return Ok(events);
            }
            return NotFound();
        }



        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {

            string Filepath = GetFilepath(id);
            var events = await eventRepository.GetByIdAsync(id);
            var imageUrl = events.URL;
           
            var imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1);
            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "Upload", imageName);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);

                events.URL = null;

                await eventRepository.DeleteAsync(id);

                return Ok("pass");
                //  return Ok(imagePath +"    pass");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("remove")]
        public async Task<IActionResult> removeImage(Guid id)
        {
            string Filepath = GetFilepath(id);
            var events = await eventRepository.GetByIdAsync(id);
            var imageUrl = events.URL;
            var imageName = imageUrl.Substring(imageUrl.LastIndexOf('/') + 1);
            var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "Upload", imageName);
            
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);

                events.URL = null;

                await eventRepository.UpdateAsync(events);

                return Ok("pass");
            
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet]
        [Route("thismonth", Name = "FiltrerParDate")]
        public async Task<IActionResult> FiltrerParDate([FromQuery] DateTime? sortBy)
        {

            var eventsDomainModel = await eventRepository.FiltrerParDate(sortBy);

            return Ok(mapper.Map<List<EventDto>>(eventsDomainModel));
        }


        [NonAction]
        public string GetFilepath(Guid id)
        {
            return this.webHostEnvironment.WebRootPath + "\\Upload\\";
        }

        //private void UploadImagValidation(IFormFile file)
        //{
        //    var exList = new string[] { ".png", ".jpg", ".jpeg" };
        //    if (!exList.Contains(Path.GetExtension(file.FileName)))
        //        ModelState.AddModelError("file", "Unsupported file extension");
        //    if(file.Length > 10485760)
        //        ModelState.AddModelError("file", "File size is then 10MB");

        //}
    }
}

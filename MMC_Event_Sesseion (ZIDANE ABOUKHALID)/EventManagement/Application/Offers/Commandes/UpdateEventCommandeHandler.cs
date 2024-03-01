using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class UpdateEventCommandeHandler : IRequestHandler<UpdateEventCommandeRequest, bool>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UpdateEventCommandeHandler(IEventRepository eventRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, IWebHostEnvironment webHostEnvironment)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<bool> Handle(UpdateEventCommandeRequest request, CancellationToken cancellationToken)
        {
           
           
                var events = await eventRepository.GetByIdAsync(request.Id);
                if (events == null)
                    {
                        return false;
                    }
                var ImagName = $"Img_Ev_{request.Id}";
                var ImagExten = Path.GetExtension(request.Event.file.FileName);
                string hosturl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";

                Uri uri = new Uri(events.URL);
                string fileName = Path.GetFileName(uri.LocalPath);
                var OldImagExten = Path.GetExtension(uri.LocalPath);

                var oldImagePath = Path.Combine(
                       webHostEnvironment.ContentRootPath,
                       "wwwroot/Upload/", $"{ImagName}{OldImagExten}"
                   );
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                var localeFilePath = Path.Combine(
                       webHostEnvironment.ContentRootPath,
                       "wwwroot/Upload", $"{ImagName}{ImagExten}"
                   );
                var stream = new FileStream(localeFilePath, FileMode.Create);
                await request.Event.file.CopyToAsync(stream);
                events.URL = $"{hosturl}/Upload/{ImagName}{ImagExten}";
                mapper.Map(request.Event, events);
                await eventRepository.UpdateAsync(events);
                return true;
            
        }
        
    }
}

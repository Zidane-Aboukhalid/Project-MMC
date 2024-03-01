using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class CreateEventCommandeHandler : IRequestHandler<CreateEventCommandeRequest, AddEventDto>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateEventCommandeHandler(IEventRepository eventRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor; // Ajout de l'injection IHttpContextAccessor
        }

        public async Task<AddEventDto> Handle(CreateEventCommandeRequest request, CancellationToken cancellationToken)
        {
            var eventDto = request.EventRequest;

           
                var events = mapper.Map<Event>(eventDto);
                events.Id = Guid.NewGuid();
                var ImagName = $"Img_Ev_{events.Id}";
                var ImagExten = Path.GetExtension(eventDto.file.FileName);

                // Utilisation de httpContextAccessor au lieu de request
                string hosturl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";

                var localeFilePath = Path.Combine(
                    webHostEnvironment.ContentRootPath,
                    "wwwroot/Upload/", $"{ImagName}{ImagExten}"
                );

                using (var stream = new FileStream(localeFilePath, FileMode.Create))
                {
                    await eventDto.file.CopyToAsync(stream);
                }

                events.URL = $"{hosturl}/Upload/{ImagName}{ImagExten}";
                events = await eventRepository.CreateAsync(events);
                var eventdto = mapper.Map<AddEventDto>(events);

                return eventdto;
           
        }

       
    }
}

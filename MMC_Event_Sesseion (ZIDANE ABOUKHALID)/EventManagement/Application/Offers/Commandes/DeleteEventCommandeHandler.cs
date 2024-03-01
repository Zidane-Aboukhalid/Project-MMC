using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteEventCommandeHandler : IRequestHandler<DeleteEventCommandeRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;
        private readonly IWebHostEnvironment environment;
        public DeleteEventCommandeHandler(IMapper mapper, IEventRepository eventRepository, IWebHostEnvironment environment)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
            this.environment = environment;
        }
        public async Task<bool> Handle(DeleteEventCommandeRequest request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetByIdAsync(request.Id);
            if (events != null)
            {
                var event1 = mapper.Map<EventDto>(events);
                var ImagName = $"Img_Ev_{request.Id}";
                var ImagExten = Path.GetExtension(event1.URL);
                var oldImagePath = Path.Combine(
                environment.ContentRootPath,
                "wwwroot/Upload/", $"{ImagName}{ImagExten}"
                   );
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
                events.URL = null;

               

                await eventRepository.DeleteAsync(request.Id);
                return true;
            }

            

            return false;
        }
        

    }
}

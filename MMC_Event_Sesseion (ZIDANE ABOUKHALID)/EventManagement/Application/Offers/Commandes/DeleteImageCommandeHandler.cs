using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteImageCommandeHandler : IRequestHandler<DeleteImageCommandeRequest, bool>
    {
        private readonly IWebHostEnvironment environment;
      //  private readonly EventManagementDbContext context;
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
        
        public DeleteImageCommandeHandler(IWebHostEnvironment environment, IEventRepository eventRepository, IMapper mapper)
        {
            this.environment = environment;
           
            this.eventRepository = eventRepository;
            this.mapper = mapper;
           
        }
        public async Task<bool> Handle(DeleteImageCommandeRequest request, CancellationToken cancellationToken)
        {
            string Filepath = GetFilepath(request.Id);
            string imagepath = Filepath + "\\" + request.Id + ".png";
            if (System.IO.File.Exists(imagepath))
            {
                System.IO.File.Delete(imagepath);

                var events = await eventRepository.GetByIdAsync(request.Id);


                events.URL = null;

                await eventRepository.UpdateAsync(events);

                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetFilepath(Guid id)
        {
            return this.environment.WebRootPath + "\\Upload\\event\\" + id;
        }
    }
}

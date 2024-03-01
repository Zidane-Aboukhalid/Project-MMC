using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetEventQueryHandler : IRequestHandler<GetEventQueryRequest, List<EventDto>>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
       

        public GetEventQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }

        public async Task<List<EventDto>> Handle(GetEventQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.IncludeSessions().ToListAsync();

         
           // var events = await eventRepository.GetAllAsync();

            return mapper.Map<List<EventDto>>(events);
        }
    }
}

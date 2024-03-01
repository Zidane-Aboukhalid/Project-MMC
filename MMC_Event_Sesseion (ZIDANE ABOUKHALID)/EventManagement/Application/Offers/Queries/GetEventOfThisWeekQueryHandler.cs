using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetEventOfThisWeekQueryHandler : IRequestHandler<GetEventOfThisWeekQueryRequest, List<EventDto>>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;

        public GetEventOfThisWeekQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {   
            this.eventRepository = eventRepository;
            this.mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetEventOfThisWeekQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetEventOfThisWeek();

            return mapper.Map<List<EventDto>>(events);
        }
    }
}

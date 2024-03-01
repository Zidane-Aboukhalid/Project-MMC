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
    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQueryRequest, EventDto>
    {
        private readonly IMapper mapper;
        private readonly IEventRepository eventRepository;

        public GetByIdEventQueryHandler(IMapper mapper, IEventRepository eventRepository)
        {
            this.mapper = mapper;
            this.eventRepository = eventRepository;
        }
        public async Task<EventDto> Handle(GetByIdEventQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await eventRepository.GetByIdAsync(request.Id);

            return mapper.Map<EventDto>(events);
        }
    }
}

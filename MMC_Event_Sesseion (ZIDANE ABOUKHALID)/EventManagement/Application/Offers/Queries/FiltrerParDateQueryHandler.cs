using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class FiltrerParDateQueryHandler : IRequestHandler<FiltrerParDateQueryRequest, List<EventDto>>
    {
        private readonly IEventRepository eventRepository;
        private readonly IMapper mapper;
       

        public FiltrerParDateQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            this.eventRepository = eventRepository;
            this.mapper = mapper;
           
        }

        public async Task<List<EventDto>> Handle(FiltrerParDateQueryRequest request, CancellationToken cancellationToken)
        {
            var eventsDomainModel = await eventRepository.FiltrerParDate(request.sortBy);

            return mapper.Map<List<EventDto>>(eventsDomainModel);
        }
    }
}

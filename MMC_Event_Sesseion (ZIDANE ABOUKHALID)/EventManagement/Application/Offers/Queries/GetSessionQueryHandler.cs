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
    public class GetSessionQueryHandler : IRequestHandler<GetSessionQueryRequest, List<SessionDto>>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;


        public GetSessionQueryHandler(IMapper mapper, ISessionRepository sessionRepository)
        {
            this.mapper = mapper;
            this.sessionRepository = sessionRepository;
        }
        public async Task<List<SessionDto>> Handle(GetSessionQueryRequest request, CancellationToken cancellationToken)
        {
            var events = await sessionRepository.GetAllAsync();

            return mapper.Map<List<SessionDto>>(events);
        }
    }
}

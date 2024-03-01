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
    public class GetByIdSessionQueryHandler : IRequestHandler<GetByIdSessionQueryRequest, SessionDto>
    {

        private readonly IMapper mapper;
        private readonly ISessionRepository sessionRepository;

        public GetByIdSessionQueryHandler(IMapper mapper, ISessionRepository sessionRepository)
        {
            this.mapper = mapper;
            this.sessionRepository = sessionRepository;
        }
        public async Task<SessionDto> Handle(GetByIdSessionQueryRequest request, CancellationToken cancellationToken)
        {
            var session = await sessionRepository.GetByIdAsync(request.Id);
            return mapper.Map<SessionDto>(session);
        }
    }
}

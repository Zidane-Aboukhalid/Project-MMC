using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudienceById
{
    public class GetSessionTargetAudienceBySessionIdQueryHandler : IRequestHandler<GetSessionTargetAudienceBySessionIdQuery, SessionTargetAudienceViewModel>
    {
        private readonly ISessionTargetAudienceRepository _sessionTargetAudienceRepository;
        private readonly IMapper _mapper;

        public GetSessionTargetAudienceBySessionIdQueryHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository, IMapper mapper)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<SessionTargetAudienceViewModel> Handle(GetSessionTargetAudienceBySessionIdQuery request, CancellationToken cancellationToken)
        {
            var sessionTA = await _sessionTargetAudienceRepository.GetBySessionIdAsync(request.SessionId);
            return _mapper.Map<SessionTargetAudienceViewModel>(sessionTA);
        }
    }
}

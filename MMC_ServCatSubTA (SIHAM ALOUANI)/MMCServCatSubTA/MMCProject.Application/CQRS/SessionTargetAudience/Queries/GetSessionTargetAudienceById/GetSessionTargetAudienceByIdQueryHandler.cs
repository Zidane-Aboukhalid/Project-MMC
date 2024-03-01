using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudienceById
{
    public class GetSessionTargetAudienceByIdQueryHandler : IRequestHandler<GetSessionTargetAudienceByIdQuery, SessionTargetAudienceViewModel>
    {
        private readonly ISessionTargetAudienceRepository _sessionTargetAudienceRepository;
        private readonly IMapper _mapper;

        public GetSessionTargetAudienceByIdQueryHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository, IMapper mapper)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
            _mapper = mapper;
        }

        public async Task<SessionTargetAudienceViewModel> Handle(GetSessionTargetAudienceByIdQuery request, CancellationToken cancellationToken)
        {
            var sessionTA = await _sessionTargetAudienceRepository.GetByIdAsync(request.SessionTargetAudienceId);
            return _mapper.Map<SessionTargetAudienceViewModel>(sessionTA);
        }
    }
}

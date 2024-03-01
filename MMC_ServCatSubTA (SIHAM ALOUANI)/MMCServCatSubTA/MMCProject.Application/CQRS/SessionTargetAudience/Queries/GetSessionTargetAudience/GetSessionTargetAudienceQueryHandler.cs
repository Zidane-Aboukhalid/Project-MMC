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

namespace MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudience
{
    public class GetSessionTargetAudienceQueryHandler : IRequestHandler<GetSessionTargetAudienceQuery, List<SessionTargetAudienceViewModel>>
    {
        private readonly ISessionTargetAudienceRepository _sessionTargetAudienceRepository;
        private readonly IMapper _mapper;
        public GetSessionTargetAudienceQueryHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository, IMapper mapper)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<List<SessionTargetAudienceViewModel>> Handle(GetSessionTargetAudienceQuery request, CancellationToken cancellationToken)
        {
            var STAs = await _sessionTargetAudienceRepository.GetAllAsync();
            var STAsList = _mapper.Map<List<SessionTargetAudienceViewModel>>(STAs);

            return STAsList;
        }
    }
}

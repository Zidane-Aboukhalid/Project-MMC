using AutoMapper;
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.TargetAudience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Queries.GetTargetAudience
{
    public class GetTargetAudienceQueryHandler : IRequestHandler<GetTargetAudienceQuery, List<TargetAudienceViewModel>>
    {
        private readonly ITargetAudienceRepository _targetAudienceRepository;
        private readonly IMapper _mapper;
        public GetTargetAudienceQueryHandler(ITargetAudienceRepository targetAudienceRepository, IMapper mapper)
        {
            _targetAudienceRepository = targetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<List<TargetAudienceViewModel>> Handle(GetTargetAudienceQuery request, CancellationToken cancellationToken)
        {
            var targetAudience = await _targetAudienceRepository.GetAllAsync();
            var targetAudienceList = _mapper.Map<List<TargetAudienceViewModel>>(targetAudience);

            return targetAudienceList;
        }
    }
}

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

namespace MMCProject.Application.CQRS.TargetAudience.Queries.GetTargetAudienceById
{
    public class GetTargetAudienceByIdQueryHandler : IRequestHandler<GetTargetAudienceByIdQuery, TargetAudienceViewModel>
    {
        private readonly ITargetAudienceRepository _targetAudienceRepository;
        private readonly IMapper _mapper;

        public GetTargetAudienceByIdQueryHandler(ITargetAudienceRepository targetAudienceRepository, IMapper mapper)
        {
            _targetAudienceRepository = targetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<TargetAudienceViewModel> Handle(GetTargetAudienceByIdQuery request, CancellationToken cancellationToken)
        {
            var targetAudience = await _targetAudienceRepository.GetByIdAsync(request.TargetAudienceId);
            return _mapper.Map<TargetAudienceViewModel>(targetAudience);
        }
    }
}

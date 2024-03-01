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

namespace MMCProject.Application.CQRS.TargetAudience.Commands.CreateTargetAudience
{
    public class CreateTargetAudienceCommandHandler : IRequestHandler<CreateTargetAudienceCommand, OpTargetAudienceViewModel>
    {
        private readonly ITargetAudienceRepository _targetAudienceRepository;
        private readonly IMapper _mapper;

        public CreateTargetAudienceCommandHandler(ITargetAudienceRepository targetAudienceRepository, IMapper mapper)
        {
            _targetAudienceRepository = targetAudienceRepository;
            _mapper = mapper;
        }
        public async Task<OpTargetAudienceViewModel> Handle(CreateTargetAudienceCommand request, CancellationToken cancellationToken)
        {

            var newTargetAudience = new Domain.Entities.TargetAudience()
            {
                NameTargetAudience=request.NameTargetAudience,
            };

            var opTargetAudience = _mapper.Map<OpTargetAudienceViewModel>(newTargetAudience);
            await _targetAudienceRepository.CreateAsync(opTargetAudience);
            return opTargetAudience;
        }
    }
}

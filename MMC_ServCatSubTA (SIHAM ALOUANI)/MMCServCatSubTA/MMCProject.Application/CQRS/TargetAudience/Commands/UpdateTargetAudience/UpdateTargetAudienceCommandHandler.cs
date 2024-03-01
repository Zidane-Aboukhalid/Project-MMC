using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.TargetAudience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Commands.UpdateTargetAudience
{
    public class UpdateTargetAudienceCommandHandler : IRequestHandler<UpdateTargetAudienceCommand, int>
    {
        public ITargetAudienceRepository _targetAudienceRepository;
        public UpdateTargetAudienceCommandHandler(ITargetAudienceRepository targetAudienceRepository)
        {
            _targetAudienceRepository = targetAudienceRepository;
        }
        public async Task<int> Handle(UpdateTargetAudienceCommand request, CancellationToken cancellationToken)
        {
            var updateTargetAudience = new OpUpdateTargetAudienceViewModel()
            {
                NameTargetAudience = request.NameTargetAudience,
            };
            return await _targetAudienceRepository.UpdateAsync(request.TargetAudienceId, updateTargetAudience);
        }
    }
}

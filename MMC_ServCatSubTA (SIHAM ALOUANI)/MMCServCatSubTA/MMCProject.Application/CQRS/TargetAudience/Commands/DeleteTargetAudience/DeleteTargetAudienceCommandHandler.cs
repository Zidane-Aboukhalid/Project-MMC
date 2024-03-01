using MediatR;
using MMCProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Commands.DeleteTargetAudience
{
    public class DeleteTargetAudienceCommandHandler : IRequestHandler<DeleteTargetAudienceCommand, Guid>
    {
        public ITargetAudienceRepository _targetAudienceRepository;
        public DeleteTargetAudienceCommandHandler(ITargetAudienceRepository targetAudienceRepository)
        {
            _targetAudienceRepository = targetAudienceRepository;
        }
        public async Task<Guid> Handle(DeleteTargetAudienceCommand request, CancellationToken cancellationToken)
        {
            return await _targetAudienceRepository.DeleteAsync(request.TargetAudienceId);
        }
    }
}

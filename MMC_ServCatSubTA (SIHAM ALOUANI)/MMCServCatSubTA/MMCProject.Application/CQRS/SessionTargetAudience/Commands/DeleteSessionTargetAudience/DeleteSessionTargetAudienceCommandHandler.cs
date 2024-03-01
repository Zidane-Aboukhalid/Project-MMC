using MediatR;
using MMCProject.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.DeleteSessionTargetAudience
{
    public class DeleteSessionTargetAudienceCommandHandler : IRequestHandler<DeleteSessionTargetAudienceCommand, Guid>
    {
        public ISessionTargetAudienceRepository _sessionTargetAudienceRepository;

        public DeleteSessionTargetAudienceCommandHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
        }
        public async Task<Guid> Handle(DeleteSessionTargetAudienceCommand request, CancellationToken cancellationToken)
        {
            return await _sessionTargetAudienceRepository.DeleteAsync(request.SessionTargetAudienceId);
        }
    }
}
    
using MediatR;
using MMCProject.Application.Interfaces;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using MMCProject.Application.ViewModel.SubCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.UpdateSessionTargetAudience
{
    public class UpdateSessionTargetAudienceCommandHandler : IRequestHandler<UpdateSessionTargetAudienceCommand, int>
    {
        public ISessionTargetAudienceRepository _sessionTargetAudienceRepository;
        public UpdateSessionTargetAudienceCommandHandler(ISessionTargetAudienceRepository sessionTargetAudienceRepository)
        {
            _sessionTargetAudienceRepository = sessionTargetAudienceRepository;
        }
        public async Task<int> Handle(UpdateSessionTargetAudienceCommand request, CancellationToken cancellationToken)
        {

            var updateSTA = new OpUpdateSessionTargetAudienceViewModel()
            {
                SessionId = request.SessionId,
                TargetAudienceId = request.TargetAudienceId
            };
            await _sessionTargetAudienceRepository.UpdateAsync(request.SessionTargetAudienceId, updateSTA);
            return 1;
        }
    }
}

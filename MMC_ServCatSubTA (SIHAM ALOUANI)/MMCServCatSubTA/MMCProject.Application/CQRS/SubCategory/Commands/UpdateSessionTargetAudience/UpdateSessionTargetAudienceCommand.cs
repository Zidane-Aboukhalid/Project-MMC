using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.UpdateSessionTargetAudience
{
    public class UpdateSessionTargetAudienceCommand : IRequest<int>
    {
        public Guid SessionTargetAudienceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid TargetAudienceId { get; set; }
    }
}

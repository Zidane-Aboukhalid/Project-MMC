using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.DeleteSessionTargetAudience
{
    public class DeleteSessionTargetAudienceCommand : IRequest<Guid>
    {
        public Guid SessionTargetAudienceId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Commands.DeleteTargetAudience
{
    public class DeleteTargetAudienceCommand : IRequest<Guid>
    {
        public Guid TargetAudienceId { get; set; }
    }
}

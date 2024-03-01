using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Commands.UpdateTargetAudience
{
    public class UpdateTargetAudienceCommand : IRequest<int>
    {
        public Guid TargetAudienceId { get; set; }
        public string NameTargetAudience { get; set; }
    }
}

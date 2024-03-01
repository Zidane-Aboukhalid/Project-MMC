using MediatR;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Commands.CreateSessionTargetAudience
{
    public class CreateSessionTargetAudienceCommand : IRequest<OpSessionTargetAudienceViewModel>
    {
        [Required]
        public Guid SessionId { get; set; }


        [Required]
        public Guid TargetAudienceId { get; set; }
    }
}

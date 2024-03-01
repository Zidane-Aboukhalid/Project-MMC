using MediatR;
using MMCProject.Application.ViewModel.SessionTargetAudience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudienceById
{
    public class GetSessionTargetAudienceByIdQuery : IRequest<SessionTargetAudienceViewModel>
    {
        public Guid SessionTargetAudienceId { get; set; }
    }
}

using MediatR;
using MMCProject.Application.ViewModel.Category;
using MMCProject.Application.ViewModel.TargetAudience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Application.CQRS.TargetAudience.Queries.GetTargetAudience
{
    public class GetTargetAudienceQuery : IRequest<List<TargetAudienceViewModel>>
    {
    }
}

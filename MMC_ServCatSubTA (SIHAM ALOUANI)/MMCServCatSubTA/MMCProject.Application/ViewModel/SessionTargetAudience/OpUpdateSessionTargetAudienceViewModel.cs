using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMCProject;

namespace MMCProject.Application.ViewModel.SessionTargetAudience
{
    public class OpUpdateSessionTargetAudienceViewModel
    {
        public Guid SessionTargetAudienceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid TargetAudienceId { get; set; }


        //public Domain.Entities.TargetAudience TargetAudience { get; set; }
    }
}

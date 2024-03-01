using MMCProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMCProject;
using MMCProject.Application.ViewModel.SessionTargetAudience;

namespace MMCProject.Application.ViewModel.TargetAudience
{
    public class TargetAudienceViewModel
    {
        public Guid TargetAudienceId { get; set; }
        public string NameTargetAudience { get; set; }
        public List<SessionTargetAudienceViewModel> SesionTargetAudiences { get; set; } 
    }
}

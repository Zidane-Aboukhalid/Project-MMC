using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Domain.Entities
{
    public class TargetAudience
    {
        
        public Guid TargetAudienceId { get; set; }
        public string NameTargetAudience { get; set; }
        public List<SessionTargetAudience> SesionTargetAudiences { get; set; } = new List<SessionTargetAudience>();

    }
}

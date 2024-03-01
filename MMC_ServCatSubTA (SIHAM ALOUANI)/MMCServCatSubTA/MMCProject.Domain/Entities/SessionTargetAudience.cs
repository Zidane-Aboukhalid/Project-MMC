using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMCProject.Domain.Entities
{
    public class SessionTargetAudience
    {
        public Guid SessionTargetAudienceId { get; set; }
        public Guid SessionId { get; set; }
        public Guid TargetAudienceId { get; set; }
        public TargetAudience TargetAudience { get; set; }
    }
}
    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.Identity
{
	public class SpeakerSession
	{
        public Guid SpeakerSessionId { get; set; }
        public Guid SessionId { get; set; }
        public Guid SpeakerId { get; set; }
        public DateTime CreateAt { get; set; }
        public virtual Speaker Speaker { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.Modales
{
	public class SelectLinkSm
	{
		public Guid LinkSmId { get; set; }
		public string Type { get; set; }
		public string Url { get; set; }
		public Guid SpeakerId { get; set; }
	}
}

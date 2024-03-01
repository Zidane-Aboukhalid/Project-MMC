using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.Modales
{
	public class SessionResponse
	{
		public string Address { get; set; }
		public DateTime DateEnd { get; set; }
		public DateTime DateStart { get; set; }
		public string Description { get; set; }
		public int NbrPlace { get; set; }
		public string Type { get; set; }
		public Guid Id { get; set; }
		public Guid EventId { get; set; }
		public string Name { get; set; }
		public Guid TargetAudienceId { get; set; }
	}
}

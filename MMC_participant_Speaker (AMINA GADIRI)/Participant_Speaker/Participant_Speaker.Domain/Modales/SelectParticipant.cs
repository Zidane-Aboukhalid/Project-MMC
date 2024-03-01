using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.Modales;

public class SelectParticipant
{
	public Guid ParticipantId { get; set; }
	public Guid IdUser { get; set; }
	public Guid IdSession { get; set; }
	public DateTime DateJoin { get; set; }
}

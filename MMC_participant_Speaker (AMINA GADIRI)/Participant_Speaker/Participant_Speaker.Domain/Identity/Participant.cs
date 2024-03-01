namespace Participant_Speaker.Domain.Identity;

public class Participant
{
	public Guid ParticipantId { get; set; }
	public Guid IdUser { get; set; }
	public Guid IdSession { get; set; }
    public DateTime DateJoin { get; set; }
}

namespace Participant_Speaker.Domain.Modales;

public class SelectSpeake
{
	 public Guid SpeakerID { get; set; }
	 public Guid IdUser { get; set; }
	public string UrlImag { get; set; }
	public bool IsMCT { get; set; }
	public bool IsMVP { get; set; } 
	public string Biographi { get; set; }
	public DateTime CreateAt { get; set; }
}
	

using Participant_Speaker.Domain.Identity;
namespace Participant_Speaker.Domain.IServices;

public interface ISpeakerRepository
{
	public Task<List<Speaker>> GetAllSpeakerAsync();
	public Task<List<Speaker>> GetAllSpeakerBySessionAsync(Guid Id);
	public Task<Speaker> GetSpeakerByIdAsync(Guid Id);
	public Task<int> CreateSpeakerAsync(Speaker speaker);
	public Task<int> UpdateSpeakerAsync(Speaker speaker);
	public Task<int> DeleteSpeakerAsync(Guid Id);
	public Task<bool> CheckUserIsSpeaker(Guid Id);
}

using Participant_Speaker.Domain.Identity;

namespace Participant_Speaker.Domain.IServices;

public interface IParticipantRepository
{
	public Task<Participant> GetParticipantByIdAsync(Guid participantId);
	public Task<List<Participant>> GetAllParticipantsAsync();
	public Task<List<Participant>> GetParticipantsBySessionAsync(Guid sessionId);
	public Task<int> AddParticipantAsync(Participant participant);
	public Task<int> UpdateParticipantAsync(Participant participant);
	public Task<int> RemoveParticipantAsync(Guid participantId);
}
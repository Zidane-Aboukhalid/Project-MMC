using Participant_Speaker.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Domain.IServices;

public interface ISpeakerSessionRepository
{
	public Task<SpeakerSession> GetSpeakerSessionByIdAsync(Guid speakerSessionId);
	public Task<List<SpeakerSession>> GetAllSpeakerSessionsAsync();
	public Task<List<SpeakerSession>> GetSpeakerSessionsBySessionAsync(Guid sessionId);
	public Task<List<SpeakerSession>> GetSpeakerSessionsBySpeakerAsync(Guid speakerId);
	public Task<int> AddSpeakerSessionAsync(SpeakerSession speakerSession);
	public Task<int> UpdateSpeakerSessionAsync(SpeakerSession speakerSession);
	public Task<int> RemoveSpeakerSessionAsync(Guid speakerSessionId);

}

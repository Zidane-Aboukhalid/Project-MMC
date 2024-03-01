using Microsoft.EntityFrameworkCore;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Infra.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Infra.Services;

public class SpeakerSessionRepository : ISpeakerSessionRepository
{
	private readonly ApplicationContext _dbContext;

	public SpeakerSessionRepository(ApplicationContext context)
    {
		this._dbContext = context;
	}
	public async Task<SpeakerSession> GetSpeakerSessionByIdAsync(Guid speakerSessionId)
	{
		return await _dbContext.SpeakerSessions.FindAsync(speakerSessionId);
	}

	public async Task<List<SpeakerSession>> GetAllSpeakerSessionsAsync()
	{
		return await _dbContext.SpeakerSessions.ToListAsync();
	}

	public async Task<List<SpeakerSession>> GetSpeakerSessionsBySessionAsync(Guid sessionId)
	{
		return await _dbContext.SpeakerSessions
			.Where(ss => ss.SessionId == sessionId)
			.ToListAsync();
	}

	public async Task<List<SpeakerSession>> GetSpeakerSessionsBySpeakerAsync(Guid speakerId)
	{
		return await _dbContext.SpeakerSessions
			.Where(ss => ss.SpeakerId == speakerId)
			.ToListAsync();
	}

	public async Task<int> AddSpeakerSessionAsync(SpeakerSession speakerSession)
	{
		_dbContext.SpeakerSessions.Add(speakerSession);
		return await _dbContext.SaveChangesAsync();
	}

	public async Task<int> UpdateSpeakerSessionAsync(SpeakerSession speakerSession)
	{
		_dbContext.Entry(speakerSession).State = EntityState.Modified;
		return await _dbContext.SaveChangesAsync();
	}

	public async Task<int> RemoveSpeakerSessionAsync(Guid speakerSessionId)
	{
		var speakerSession = await _dbContext.SpeakerSessions.FindAsync(speakerSessionId);
		if (speakerSession != null)
		{
			_dbContext.SpeakerSessions.Remove(speakerSession);
			return await _dbContext.SaveChangesAsync();
		}
		return 0;
	}
}

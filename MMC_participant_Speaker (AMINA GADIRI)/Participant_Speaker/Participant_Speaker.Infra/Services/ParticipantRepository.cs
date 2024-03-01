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

public class ParticipantRepository : IParticipantRepository
{
	private readonly ApplicationContext _dbContext;

	public ParticipantRepository(ApplicationContext context)
    {
		this._dbContext = context;
	}
	public async Task<Participant> GetParticipantByIdAsync(Guid participantId)
	{
		return await _dbContext.Participants.FindAsync(participantId);
	}

	public async Task<List<Participant>> GetAllParticipantsAsync()
	{
		return await _dbContext.Participants.ToListAsync();
	}

	public async Task<List<Participant>> GetParticipantsBySessionAsync(Guid sessionId)
	{
		return await _dbContext.Participants
			.Where(p => p.IdSession == sessionId)
			.ToListAsync();
	}

	public async Task<int> AddParticipantAsync(Participant participant)
	{
		_dbContext.Participants.Add(participant);
		return await _dbContext.SaveChangesAsync();
	}

	public async Task<int> UpdateParticipantAsync(Participant participant)
	{
		_dbContext.Entry(participant).State = EntityState.Modified;
		return await _dbContext.SaveChangesAsync();
	}

	public async Task<int> RemoveParticipantAsync(Guid participantId)
	{
		var participant = await _dbContext.Participants.FindAsync(participantId);
		if (participant != null)
		{
			_dbContext.Participants.Remove(participant);
			return await _dbContext.SaveChangesAsync();
		}
		return 0;
	}
}

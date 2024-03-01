
using Microsoft.EntityFrameworkCore;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Infra.data;

namespace Participant_Speaker.Infra.Services;

public class SpeakerRepository : ISpeakerRepository
{
	private readonly ApplicationContext context;

	public SpeakerRepository(ApplicationContext context)
    {
		this.context = context;
	}

	public async Task<bool> CheckUserIsSpeaker(Guid Id)
	{
		var speaker = await context.Speakers.FirstOrDefaultAsync(x=> x.IdUser == Id);
		return speaker is null ? false : true;
	}

	public async Task<int> CreateSpeakerAsync(Speaker speaker)
	{
		if (speaker != null)
		{
			await context.Speakers.AddAsync(speaker);
			return await context.SaveChangesAsync();
		}
		else
			return 0;
	}

	public async Task<int> DeleteSpeakerAsync(Guid Id)
	{
		var skp= context.Speakers.FirstOrDefault(x=> x.SpeakerID==Id);
		if (skp != null)
		{
			context.Speakers.Remove(skp);
			return await context.SaveChangesAsync() ;
		}
		else 
			return 0;
	}

	public async Task<List<Speaker>> GetAllSpeakerAsync()
	{
		return await context.Speakers.ToListAsync();
	}


	public async Task<Speaker> GetSpeakerByIdAsync(Guid Id)
	{
		Speaker speaker = await context.Speakers.FirstOrDefaultAsync(x => x.SpeakerID == Id);
		return speaker;
		 
	}

	public async Task<int> UpdateSpeakerAsync(Speaker speaker)
	{
		var spk = await context.Speakers.FirstOrDefaultAsync(x => x.SpeakerID == speaker.SpeakerID);
		if (spk != null)
		{
			spk.UrlImag = speaker.UrlImag;
			spk.IsMVP = speaker.IsMVP;
			spk.IsMCT = speaker.IsMCT;
			spk.UpdateAt= speaker.UpdateAt;
			spk.Biographi = speaker.Biographi;
			return await context.SaveChangesAsync();
		}
		return 0;
	}
	public async Task<List<Speaker>> GetAllSpeakerBySessionAsync(Guid Id)
	{
		return await context.Speakers
			.Where(op=> op.SpeakerID==Id)
			.ToListAsync();
	}
}
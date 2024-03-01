using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Participant_Speaker.Application.SpeakerSessions.Command;
using Participant_Speaker.Application.SpeakerSessions.Queries;

namespace Participant_Speaker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpeakerSessionController : ControllerBase
	{
		private readonly IMediator mediator;

		public SpeakerSessionController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		[Authorize(Roles = "Admin")]
		[HttpGet("GetAllSpeakerSessions")]
		public async Task<IActionResult> GetAllSpeakerSessions(CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(new GetAllSpeakerSessions(), cancellationToken));
		}
		[HttpPost("GetSpeakerSessionById")]
		public async Task<IActionResult> GetSpeakerSessionById([FromBody]GetSpeakerSessionById getSpeakerSessionById,CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(getSpeakerSessionById,cancellationToken));
		}
		[Authorize(Roles = "Admin")]
		[HttpPost("GetSpeakerSessionsBySession")]
		public async Task<IActionResult> GetSpeakerSessionsBySession([FromBody] GetSpeakerSessionsBySession getSpeakerSessionsBySession, CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(getSpeakerSessionsBySession, cancellationToken));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("GetSpeakerSessionsBySpeaker")]
		public async Task<IActionResult> GetSpeakerSessionsBySpeaker([FromBody] GetSpeakerSessionsBySpeaker getSpeakerSessionsBySpeaker, CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(getSpeakerSessionsBySpeaker, cancellationToken));
		}
		[Authorize(Roles = "Admin")]
		[HttpPost("AddSpeakerSession")]
		public async Task<IActionResult> AddSpeakerSession([FromBody] AddSpeakerSession addSpeakerSession,CancellationToken cancellationToken)
		{
		 var res= await mediator.Send(addSpeakerSession,cancellationToken);
			return res switch
			{
				1 => Ok("Create Speaker Session Is Sucsses"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}
		[Authorize(Roles = "Admin")]
		[HttpPut("UpdateSpeakerSession")]
		public async Task<IActionResult> UpdateSpeakerSession([FromBody] UpdateSpeakerSession updateSpeakerSession, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(updateSpeakerSession, cancellationToken);
			return res switch
			{
				1 => Ok("Update Speaker Session Is Sucsses"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}
		[Authorize(Roles = "Admin")]
		[HttpDelete("RemoveSpeakerSession")]
		public async Task<IActionResult> RemoveSpeakerSession([FromBody] RemoveSpeakerSession removeSpeakerSession, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(removeSpeakerSession, cancellationToken);
			return res switch
			{
				1 => Ok("Delete Speaker Session Is Sucsses"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}


	}
}

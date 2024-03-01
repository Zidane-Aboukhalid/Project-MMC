using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Participant_Speaker.Application.Participants.Command;
using Participant_Speaker.Application.Participants.Queries;


namespace Participant_Speaker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipantController : ControllerBase
{
	private readonly IMediator mediator;

	public ParticipantController(IMediator mediator)
    {
		this.mediator = mediator;
	}
	[Authorize(Roles = "Admin")]
	[HttpGet("GetAllParticipants")]
	public async Task<IActionResult> GetAllParticipants(CancellationToken cancellationToken)
	{
		return Ok(await mediator.Send(new GetAllParticipants(), cancellationToken));
	}
	[Authorize(Roles = "Admin")]
	[HttpPost("GetParticipantsBySession")]
	public async Task<IActionResult> GetParticipantsBySession([FromBody] GetParticipantsBySession getParticipantsBySession ,CancellationToken cancellationToken)
	{
		return Ok(await mediator.Send(getParticipantsBySession, cancellationToken));
	}
	[Authorize(Roles = "Admin,User")]
	[HttpPost("GetParticipantById")]
	public async Task<IActionResult> GetParticipantById([FromBody] GetParticipantById getParticipantById ,CancellationToken cancellationToken)
	{
		return Ok(await mediator.Send(getParticipantById, cancellationToken));
	}

	[Authorize(Roles = "Admin,User")]
	[HttpPost("AddParticipant")]
	public async Task<IActionResult> AddParticipant([FromBody] AddParticipant addParticipant,CancellationToken cancellationToken)
	{
		var res= await mediator.Send(addParticipant, cancellationToken);
		return res switch
		{
			1=> Ok(addParticipant),
			0 => Conflict(),
			3=> Conflict("Send Email fild !"),
			_ => throw new NotSupportedException()
		};
	}

	[Authorize(Roles = "Admin,User")]
	[HttpPut("UpdateParticipant")]
	public async Task<IActionResult> PutUpdateParticipant([FromBody]UpdateParticipant updateParticipant,CancellationToken cancellationToken)
	{
		var res= await mediator.Send(updateParticipant, cancellationToken);
		return res switch
		{
			1 => Ok(updateParticipant),
			0 => Conflict(),
			_ => throw new NotSupportedException()
		};
	}
	[Authorize(Roles = "Admin,User")]
	[HttpDelete("RemoveParticipant")]
	public async Task<IActionResult> RemoveParticipant([FromBody]RemoveParticipant removeParticipant, CancellationToken cancellationToken)
	{
		var res=await mediator.Send(removeParticipant, cancellationToken);
		return res switch
		{
			1 => Ok("Delete Done"),
			0 => Conflict(),
			_ => throw new NotSupportedException()
		};
	}
}
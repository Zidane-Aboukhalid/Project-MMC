using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Participant_Speaker.Application.Speakes.Command;
using Participant_Speaker.Application.Speakes.Queries;
using Participant_Speaker.Domain.Modales;

namespace Participant_Speaker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "Admin")]
	public class SpeakerController : ControllerBase
	{
		private readonly IMediator mediator;

		public SpeakerController(IMediator mediator)
        {
			this.mediator = mediator;
		}

		
		[HttpGet("GetAllSpeakers")]
		public async Task<IActionResult> getAllSpeaker(CancellationToken cancellationToken)
			=> Ok(await mediator.Send(new getAllSpeaker(), cancellationToken));

		[HttpGet("GetAllSpeakerBySessions")]
		public async Task<IActionResult> GetAllSpeakerBySessions([FromBody]GetAllSpeakerBySessions getAllSpeakerBySessions ,CancellationToken cancellationToken)
		=> Ok(await mediator.Send(getAllSpeakerBySessions, cancellationToken));


		[HttpGet("GetSpeakersById")]
		public async Task<IActionResult> GetSpeakersById([FromBody]GetSpeakerById getSpeakerById,CancellationToken cancellationToken)
		{
			if(ModelState.IsValid)
			{
				return Ok(await mediator.Send(getSpeakerById, cancellationToken));
			}
			return BadRequest("Error ");
		}
		[AllowAnonymous]
		[HttpGet("CheckUserIsSpeakers")]
		public async Task<IActionResult> CheckUserIsSpeakers([FromBody] CheckUserIsSpeakers checkUserIsSpeakers, CancellationToken cancellationToken)
			=> Ok(await mediator.Send(checkUserIsSpeakers));

		[HttpPost("CreateSpeakers")]
		public async Task<IActionResult> CreateSpeakers([FromForm] CreateSpeakes createSpeakes , CancellationToken cancellationToken)
		{
			var res=  await mediator.Send(createSpeakes, cancellationToken);
				return res switch
				{
					1=>Ok("Create Speake Is Sucsses"),
					0 => Conflict(),
					_ => throw new NotSupportedException()
				};
		}

		[HttpPut("UpdateSpeaker")]
		public async Task<IActionResult> UpdateSpeaker([FromBody] UpdateSpeakes updateSpeakes, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(updateSpeakes, cancellationToken);
			return res switch
			{
				1 => Ok("Update Speake Is Sucsses"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}

		[HttpPut("DeleteSpeakes")]
		public async Task<IActionResult> DeleteSpeakes([FromBody] DeleteSpeakes deleteSpeakes, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(deleteSpeakes, cancellationToken);
			return res switch
			{
				1 => Ok("Delete Speake Is Sucsses"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}

	}
}

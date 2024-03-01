using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Participant_Speaker.Application.LinkSms.Command;
using Participant_Speaker.Application.LinkSms.Queries;

namespace Participant_Speaker.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LinkSmController : ControllerBase
	{
		private readonly IMediator mediator;

		public LinkSmController(IMediator mediator)
        {
			this.mediator = mediator;
		}

		[HttpGet("GetAllLinkSms")]
		public async Task<IActionResult> GetAllLinkSms(CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(new GetAllLinkSms(), cancellationToken));
		}
		[HttpPost("GetLinkSmById")]
		public async Task<IActionResult> GetLinkSmById([FromBody] GetLinkSmById linkSmById, CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(linkSmById, cancellationToken));
		}

		[HttpPost("GetLinkSmsBySpeaker")]
		public async Task<IActionResult> GetLinkSmsBySpeaker([FromBody] GetLinkSmsBySpeaker getLinkSmsBySpeaker, CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(getLinkSmsBySpeaker, cancellationToken));
		}

		[HttpPost("AddLinkSm")]
		public async Task<IActionResult> AddLinkSm([FromBody] AddLinkSm addLinkSm, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(addLinkSm, cancellationToken);
			return res switch
			{
				1 => Ok(addLinkSm),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}


		[HttpPut("UpdateLinkSm")]
		public async Task<IActionResult> UpdateLinkSm([FromBody] UpdateLinkSm updateLinkSm, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(updateLinkSm, cancellationToken);
			return res switch
			{
				1 => Ok(updateLinkSm),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}


		[HttpDelete("RemoveLinkSm")]
		public async Task<IActionResult> RemoveLinkSm([FromBody] RemoveLinkSm removeLinkSm, CancellationToken cancellationToken)
		{
			var res = await mediator.Send(removeLinkSm, cancellationToken);
			return res switch
			{
				1 => Ok("Delete Done"),
				0 => Conflict(),
				_ => throw new NotSupportedException()
			};
		}
	}
}

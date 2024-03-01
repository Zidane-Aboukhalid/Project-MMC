using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMCProject.Application.CQRS.SessionTargetAudience.Commands.CreateSessionTargetAudience;
using MMCProject.Application.CQRS.SessionTargetAudience.Commands.DeleteSessionTargetAudience;
using MMCProject.Application.CQRS.SessionTargetAudience.Commands.UpdateSessionTargetAudience;
using MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudience;
using MMCProject.Application.CQRS.SessionTargetAudience.Queries.GetSessionTargetAudienceById;

namespace MMCProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTargetAudienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SessionTargetAudienceController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet("GetAllSessionTargetAudience")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var STAs = await _mediator.Send(new GetSessionTargetAudienceQuery());
            return Ok(STAs);
        }


        [HttpGet("GetSessionTargetAudienceById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var SessionTA = await _mediator.Send(new GetSessionTargetAudienceByIdQuery() { SessionTargetAudienceId = id });

            if (SessionTA == null)
            {
                return NotFound();
            }

            return Ok(SessionTA);
        }



        [HttpGet("GetSessionTargetAudienceBySessionId/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetBySessionId([FromRoute]Guid Id)
        {
            var SessionTA = await _mediator.Send(new GetSessionTargetAudienceBySessionIdQuery() { SessionId = Id });

            if (SessionTA == null)
            {
                return NotFound();
            }

            return Ok(SessionTA);
        }



        [HttpPost("CreateSessionTargetAudience")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateSessionTargetAudienceCommand command)
        {
            var newSTA = await _mediator.Send(command);
            return Ok(newSTA);
        }



        [HttpPut("UpdateSessionTargetAudience")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateSessionTargetAudienceCommand command)
        {
            var res = await _mediator.Send(command);

            return res switch
            {
                1 => Ok(),
                0 => Conflict(),
                _ => throw new NotSupportedException()
            };
        }




        [HttpDelete("DeleteSessionTargetAudience/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSessionTargetAudienceCommand { SessionTargetAudienceId = id });
            return NoContent();
        }

    }
}

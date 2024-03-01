using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMCProject.Application.CQRS.TargetAudience.Commands.CreateTargetAudience;
using MMCProject.Application.CQRS.TargetAudience.Commands.DeleteTargetAudience;
using MMCProject.Application.CQRS.TargetAudience.Commands.UpdateTargetAudience;
using MMCProject.Application.CQRS.TargetAudience.Queries.GetTargetAudience;
using MMCProject.Application.CQRS.TargetAudience.Queries.GetTargetAudienceById;

namespace MMCProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetAudienceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TargetAudienceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTargetAudience")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var targetAudience = await _mediator.Send(new GetTargetAudienceQuery());
            return Ok(targetAudience);
        }




        [HttpGet("GetTargetAudienceById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var targetAudience = await _mediator.Send(new GetTargetAudienceByIdQuery() { TargetAudienceId = id });

            if (targetAudience == null)
            {
                return NotFound();
            }

            return Ok(targetAudience);
        }



        [HttpPost("CreateTargetAudience")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateTargetAudienceCommand command)
        {
            var newTA = await _mediator.Send(command);
            return Ok(newTA);
        }


        [HttpPut("UpdateTargetAudience")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateTargetAudienceCommand command)
        {
            var res = await _mediator.Send(command);

            return res switch
            {
                1 => Ok(),
                0 => Conflict(),
                _ => throw new NotSupportedException()
            };
        }



        [HttpDelete("DeleteTargetAudience/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTargetAudienceCommand { TargetAudienceId = id });
            return NoContent();
        }
    }
}

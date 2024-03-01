using Application.CustomActionFilters;
using Application.DTO;
using Application.Offers.Commandes;
using Application.Offers.Queries;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SessionController : ControllerBase
    {
       private readonly IMediator mediator;

        public SessionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetSessions")]

        public async Task<IActionResult> GetAll()
        {
            
            var query = new GetSessionQueryRequest();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]
		public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var query = new GetByIdSessionQueryRequest(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
        [HttpGet("CheckSessionexisting/{id:Guid}")]
    
        public async Task<IActionResult> CheckSessionexisting([FromRoute] Guid id)
        {
            var query = new GetByIdSessionQueryRequest(id);
            var result = await mediator.Send(query);
            return result != null ? Ok(true) : Ok(false);

        }

       [Authorize(Roles = "Admin")]
        [HttpPost("CreateSession")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddSessionDto sessionDto)
        {
            var command = new CreateSessionCommandeRequest(sessionDto);
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ValidateModel]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddSessionDto sessionDto)
        {
           
            if (!ModelState.IsValid)
                return BadRequest();

            var commande = new UpdateSessionCommandeRequest(id, sessionDto);
            var result = await mediator.Send(commande);
            return result ? Ok("Done") : BadRequest();

        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Romove/{id:Guid}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var command = new DeleteSessionCommandeRequest(id);
            var result = await mediator.Send(command);

            return result ? Ok("Done") : BadRequest();
        }

    }
}

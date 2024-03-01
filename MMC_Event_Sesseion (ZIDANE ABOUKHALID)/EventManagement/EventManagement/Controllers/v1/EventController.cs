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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EventController : ControllerBase
    {
        private readonly IMediator mediator;
       
        public EventController(IMediator mediator)
        {
           this.mediator = mediator;
          
        }

       
        [HttpGet("GetEvents")]
		public async Task<IActionResult> GetAllwithoutsessions()
        {
            var query = new GetEventQueryRequest();
            var result = await mediator.Send(query);
            
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById/{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetByIdEventQueryRequest(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet]
        [Route("thisweek", Name = "GetEventOfThisWeek")]
        public async Task<IActionResult> GetEventOfThisWeek()
        {
            var query = new GetEventOfThisWeekQueryRequest();
            var result = await mediator.Send(query);

            return Ok(result);
        }
        [HttpGet]
        [Route("thismonth", Name = "FiltrerParDate")]
        public async Task<IActionResult> FiltrerParDate([FromQuery] DateTime? sortBy)
        {

            var query = new FiltrerParDateQueryRequest(sortBy);
            var result = await mediator.Send(query);

            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateEvent")]
        [ValidateModel]
        
        public async Task<IActionResult> Create([FromForm]AddEventDto eventDto)
        {
            
            var command = new CreateEventCommandeRequest(eventDto);
            var result = await mediator.Send(command);
            
            return Ok(result);

        }


        [Authorize(Roles = "Admin")]
        [HttpPut]
        [ValidateModel]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id , [FromForm]AddEventDto eventDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var commande = new UpdateEventCommandeRequest(id, eventDto);
            var result = await mediator.Send(commande);
            return result ? Ok("Done") : NotFound();

        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Romove/{id:Guid}")]
        public async Task<IActionResult> Romove([FromRoute] Guid id)
        {
            
            var command = new DeleteEventCommandeRequest(id);
            var result = await mediator.Send(command);

            return result ? Ok("Done") : BadRequest();

        }
    }
}

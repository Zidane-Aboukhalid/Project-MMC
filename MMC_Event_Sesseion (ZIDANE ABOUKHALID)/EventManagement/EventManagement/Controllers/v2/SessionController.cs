using Application.CustomActionFilters;
using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;

        public SessionController(ISessionRepository sessionRepository, IMapper mapper)
        {
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var session = await sessionRepository.GetAllAsync();

            return Ok(mapper.Map<List<SessionDto>>(session));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var session = await sessionRepository.GetByIdAsync(id);

            if (session == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<SessionDto>(session));

        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddSessionDto sessionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = mapper.Map<Session>(sessionDto);
            session = await sessionRepository.CreateAsync(session);

            var sessiondto = mapper.Map<SessionDto>(session);


            return Ok(sessiondto);
        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] AddSessionDto sessionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var existingsession = await sessionRepository.GetByIdAsync(id);

            mapper.Map(sessionDto, existingsession);
            sessionRepository.UpdateAsync(existingsession);

            return Ok(existingsession);

        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            var session = await sessionRepository.DeleteAsync(id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok("done");
        }
    }
}

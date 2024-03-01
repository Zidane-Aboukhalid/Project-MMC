using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMCProject.Application.CQRS.Category.Commands.CreateCategory;
using MMCProject.Application.CQRS.Category.Commands.DeleteCategory;
using MMCProject.Application.CQRS.Category.Commands.UpdateCategory;
using MMCProject.Application.CQRS.Category.Queries.GetCategories;
using MMCProject.Application.CQRS.Category.Queries.GetCategoryById;

namespace MMCProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }





        [HttpGet("GetAllCategories")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _mediator.Send(new GetCategoryQuery());
            return Ok(categories);
        }




        [HttpGet("GetCategoryById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery() { CategoryId = id });

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }





        [HttpPost("CreateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            var newCat= await _mediator.Send(command);
            return Ok( newCat);
        }






        [HttpPut("UpdateCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update( UpdateCategoryCommand command)
        {
          var res =  await _mediator.Send(command);
          
            return res switch
            {
                1 => Ok(),
                0 => Conflict(),
                _ => throw new NotSupportedException()
            };
        }





        [HttpDelete("DeleteCategory/{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteCategoryCommand { CategoryId = id });
            return NoContent();
        }



    }    

}

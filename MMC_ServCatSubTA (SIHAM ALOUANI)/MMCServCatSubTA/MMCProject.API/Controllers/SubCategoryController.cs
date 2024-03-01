using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MMCProject.Application.CQRS.SubCategory.Commands.CreateSubCategory;
using MMCProject.Application.CQRS.SubCategory.Commands.DeleteSubCategory;
using MMCProject.Application.CQRS.SubCategory.Commands.UpdateSubCategory;
using MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategories;
using MMCProject.Application.CQRS.SubCategory.Queries.GetSubCategoryById;

namespace MMCProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;   
        }


        [HttpGet("GetAllSubCategories")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var subCategories = await _mediator.Send(new GetSubCategoriesQuery());
            return Ok(subCategories);
        }


        [HttpGet("GetSubCategoryById/{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var subCategory = await _mediator.Send(new GetSubCategoryByIdQuery() { SubCategoryId = id });

            if (subCategory == null)
            {
                return NotFound();
            }

            return Ok(subCategory);
        }


        [HttpPost("CreateSubCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateSubCategoryCommand command)
        {
            var newSubCat = await _mediator.Send(command);
            return Ok(newSubCat);
        }



        [HttpPut("UpdateSubCategory")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateSubCategoryCommand command)
        {
            var res = await _mediator.Send(command);

            return res switch
            {
                1 => Ok(),
                0 => Conflict(),
                _ => throw new NotSupportedException()
            };
        }



        [HttpDelete("DeleteSubCategory/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteSubCategoryCommand { SubCategoryId = id });
            return NoContent();
        }
    }
}

using AppDomain.Common.Entities;
using AppDomain.DTOs.Category;
using AppDomain.Entities.TagBaseRelated;
using Application.Tasks.Commands.Insert.InsertCategory;
using Application.Tasks.Queries.CategoryQueries.GetAllCategory;
using Application.Tasks.Queries.CategoryQueries.GetAllCategoryBuild;
using Application.Tasks.Queries.CategoryQueries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllCategoryBuildProfile")]
        public async Task<ActionResult<List<CategoryBuildProfileDTO>>> GetAllCategoryBuildProfile()
        {
            var result = await _mediator.Send(new GetAllCategoryBuildProfileQuery());

            if (result.Count is 0)
                return NotFound("Category is Empty");

            return Ok(result);
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            var categoryList = await _mediator.Send(new GetAllCategoryQuery());

            if (categoryList.Count is 0)
                return NotFound("Category is Empty");

            return Ok(categoryList);
        }

        [HttpGet("GetCategoryById/{CategoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(GetCategoryByIdQuery query)
        {
            var categoryGet = await _mediator.Send(query);

            if (categoryGet is null)
            {
                GeneralResponce responce = new() { Result = 0, Message = $"Category is not exist in this id = {query.CategoryId}" };
                return NotFound(responce);
            }
            else
            {
                return Ok(categoryGet);
            }

        }

        [HttpPost("InsertCategory")]
        public async Task<ActionResult> InsertCategory([FromBody] InsertCategoryCommand command)
        {
            var insertedId = await _mediator.Send(command);

            GeneralResponce responce = new() { Result = insertedId, Message = $"Category Id: {insertedId} inserted successfully" };

            return Ok(responce);
        }

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory()
        {
            return Ok();
        }
    }
}

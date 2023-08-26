using AppDomain.Common.Entities;
using AppDomain.DTOs.Category;
using AppDomain.Entities.TagBaseRelated;
using Application.Tasks.Commands.Delete.DeleteArticleFLag;
using Application.Tasks.Commands.Delete.DeleteCategory;
using Application.Tasks.Commands.Insert.InsertArticleFlag;
using Application.Tasks.Commands.Insert.InsertCategory;
using Application.Tasks.Commands.Update.UpdateArticleFlag;
using Application.Tasks.Commands.Update.UpdateCategory;
using Application.Tasks.Queries.ArticleFlagQueries.GetAllArticleFlag;
using Application.Tasks.Queries.ArticleFlagQueries.GetArticleFlagById;
using Application.Tasks.Queries.CategoryQueries.GetAllCategory;
using Application.Tasks.Queries.CategoryQueries.GetAllCategoryBuild;
using Application.Tasks.Queries.CategoryQueries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all available category build profiles.
        /// </summary>
        /// <returns>A list of category build profiles.</returns>
        
        [HttpGet("GetAllCategoryBuildProfile")]
        public async Task<ActionResult<List<CategoryBuildProfileDTO>>> GetAllCategoryBuildProfile()
        {
            var result = await _mediator.Send(new GetAllCategoryBuildProfileQuery());

            if (result.Count is 0)
                return NotFound("Category is Empty");

            return Ok(result);
        }

        /// <summary>
        /// Retrieves all available categories.
        /// </summary>
        /// <returns>A list of categories.</returns>
        
        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            var categoryList = await _mediator.Send(new GetAllCategoryQuery());

            if (categoryList.Count is 0)
                return NotFound("Category is Empty");

            return Ok(categoryList);
        }

        /// <summary>
        /// Retrieves a category using its unique identifier.
        /// </summary>
        /// <param name="query">Query containing the category identifier.</param>
        /// <returns>The requested category, or a "Not Found" response if not found.</returns>
   
        [HttpGet("GetCategoryById/{CategoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(GetCategoryByIdQuery query)
        {
            var categoryGet = await _mediator.Send(query);

            if (categoryGet is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"Category is not exist in this id = {query.CategoryId}" };
                return NotFound(response);
            }
            else
            {
                return Ok(categoryGet);
            }
        }

        /// <summary>
        /// Inserts a new category.
        /// </summary>
        /// <param name="command">The command containing category information.</param>
        /// <returns>A success response with the inserted category ID.</returns>
        
        [HttpPost("InsertCategory")]
        public async Task<ActionResult> InsertCategory([FromBody] InsertCategoryCommand command)
        {
            var insertedId = await _mediator.Send(command);

            GeneralResponse response = new() { Result = insertedId, Message = $"Category Id: {insertedId} inserted successfully" };

            return Ok(response);
        }

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="command">The command for updating category information.</param>
        /// <returns>A response indicating success or a "Not Found" response if the category doesn't exist.</returns>

        [HttpPut("UpdateCategory")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            var updatedId = await _mediator.Send(command);

            if(updatedId is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"Category Id: {command.updateCategoryDTO.Id} is not exist, Update process failed" };
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = updatedId, Message = $"Category Id: {updatedId}, Update process successfully" };
                return Ok(response);
            }
                
        }

        /// <summary>
        /// Deletes a category using its identifier.
        /// </summary>
        /// <param name="command">The command containing the category identifier.</param>
        /// <returns>A response indicating deletion success or a "Not Found" response if the category doesn't exist.</returns>

        [HttpDelete("DeleteCategory/{CategoryId}")]
        public async Task<ActionResult> DeleteCategory(DeleteCategoryCommand command)
        {
            var deleted = await _mediator.Send(command);

            if (deleted is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"Category Id: {command.CategoryId} is not exist, Delete process failed" };
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = deleted, Message = $"Category Id: {deleted}, Delete process successfully" };
                return Ok(response);
            }
        }

        /// <summary>
        /// Increments the usage count of a category list.
        /// </summary>
        /// <param name="command">The command for incrementing the usage count.</param>
        /// <returns>A response indicating the success of the increment operation or a failure response.</returns>

        [HttpPatch("IncrementCategoryListUseCount")]
        public async Task<ActionResult> IncrementCategoryUseCount([FromBody]IncrementCategoryUseCountCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is 1)
            {
                GeneralResponse response = new() { Result = 1, Message = $"CategoryList Increment UseCount process successfully" };  
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = 0, Message = $"CategoryList Increment UseCount process failed" };
                return Ok(response);
            }
        }

        /// <summary>
        /// Decrements the usage count of a category list.
        /// </summary>
        /// <param name="command">The command for decrementing the usage count.</param>
        /// <returns>A response indicating the success of the decrement operation or a failure response.</returns>

        [HttpPatch("DecrementCategoryListUseCount")]
        public async Task<ActionResult> DecrementCategoryListUseCount([FromBody]DecrementCategoryListUseCountCommand command)
        {
            var result = await _mediator.Send(command);

            if (result is 1)
            {
                GeneralResponse response = new() { Result = 1, Message = $"CategoryList Decrement UseCount process successfully" };
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = 0, Message = $"CategoryList Decrement UseCount process failed" };
                return Ok(response);
            }
        }


        [HttpGet("GetAllArticleFlag")]
        public async Task<ActionResult<List<ArticleFlag>>> GetAllArticleFlag()
        {
            var result = await _mediator.Send(new GetAllArticleFlagQuery());

            if(result.Count is 0)
            {
                GeneralResponse response = new() { Result = 0,Message = "ArticleFlag List is Empty"};
                return NotFound(response);
            }
            return Ok(result);
        }

        [HttpGet("GetAllArticleById/{ArticleFlagId}")]
        public async Task<ActionResult<Category>> GetAllArticleById(GetArticleFlagByIdQuery query)
        {
            var getArticleFlag = await _mediator.Send(query);

            if (getArticleFlag is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"ArticleFlag is not exist in this id = {query.ArticleFlagId}" };
                return NotFound(response);
            }
            else
            {
                return Ok(getArticleFlag);
            }

        }

        [HttpPost("InsertArticleFlag")]
        public async Task<ActionResult<string>> InsertArticleFlag([FromBody]InsertArticleFlagCommand command)
        {
            var insertedId = await _mediator.Send(command);

            GeneralResponse response = new() { Result = insertedId, Message = $"ArticleFlag Id: {insertedId} inserted successfully" };

            return Ok(response);
        }

        [HttpPut("UpdateArticleFlag")]
        public async Task<ActionResult> UpdateArticleFlag([FromBody]UpdateArticleFlagCommand command)
        {
            var updatedId = await _mediator.Send(command);

            if (updatedId is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"ArticleFlag Id: {command.UpdateArticleFlagDTO.Id} is not exist, Update process failed" };
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = updatedId, Message = $"ArticleFlag Id: {updatedId}, Update process successfully" };
                return Ok(response);
            }

        }

        [HttpDelete("DeleteArticleFLag/{ArticleFLagId}")]
        public async Task<ActionResult> DeleteArticleFLag(DeleteArticleFLagCommand command)
        {
            var deleted = await _mediator.Send(command);

            if (deleted is null)
            {
                GeneralResponse response = new() { Result = 0, Message = $"ArticleFLag Id: {command.ArticleFLagId} is not exist, Delete process failed" };
                return NotFound(response);
            }
            else
            {
                GeneralResponse response = new() { Result = deleted, Message = $"ArticleFLag Id: {deleted}, Delete process successfully" };
                return Ok(response);
            }
        }
    }
}
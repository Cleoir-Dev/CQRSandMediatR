using CQRSandMediatR.Commands.CategoryCommand.cs;
using CQRSandMediatR.Models;
using CQRSandMediatR.Queries.CategoryQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRSandMediatR.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<List<CategoryModel>> GetListAsync()
        {

            var categories = await _mediator.Send(new GetListCategoryQuery());

            return categories.ToList();
        }

        [HttpGet("id")]
        [Authorize]
        public async Task<CategoryModel> GetByIdAsync(Guid id)
        {
            var category = await _mediator.Send(new GetByIdCategoryQuery() { Id = id });

            if (category == null)
            {
                return new CategoryModel("Not Category");
            }

            return category;
        }


        [HttpPost]
        [Authorize(Roles = UserRoles.User)]
        public async Task<int> AddAsync(string title)
        {
            var id = await _mediator.Send(new CreateCategoryCommand(title));
            return id;
        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<int> UpdateAsync(CategoryModel category)
        {
            var id = await _mediator.Send(new UpdateCategoryCommand(category.Id, category.Title));
            return id;
        }

        [HttpDelete]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<int> DeleteAsync(Guid id)
        {
            return await _mediator.Send(new DeleteCategoryCommand() { Id = id });
        }

    }
}

using CQRSandMediatR.Models;
using CQRSandMediatR.Queries.CategoryQuery;
using CQRSandMediatR.Repositories.CategoryRepository;
using MediatR;

namespace CQRSandMediatR.Handlers.CategoryHandler
{
    public class CategoryGetByIdHandler : IRequestHandler<GetByIdCategoryQuery, CategoryModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryModel> Handle(GetByIdCategoryQuery query, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(query.Id);
        }
    }
}

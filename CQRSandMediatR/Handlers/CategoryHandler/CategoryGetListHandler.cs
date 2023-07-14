using CQRSandMediatR.Models;
using CQRSandMediatR.Queries.CategoryQuery;
using CQRSandMediatR.Repositories.CategoryRepository;
using MediatR;

namespace CQRSandMediatR.Handlers.CategoryHandler
{
    public class CategoryGetListHandler : IRequestHandler<GetListCategoryQuery, List<CategoryModel>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryGetListHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryModel>> Handle(GetListCategoryQuery query, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetListAsync();
        }
    }
}

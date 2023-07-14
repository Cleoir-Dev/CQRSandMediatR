using CQRSandMediatR.Commands.CategoryCommand.cs;
using CQRSandMediatR.Models;
using CQRSandMediatR.Repositories.CategoryRepository;
using MediatR;

namespace CQRSandMediatR.Handlers.CategoryHandler
{
    public class CategoryCreateHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCreateHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = new CategoryModel(command.Title);
            return await _categoryRepository.AddAsync(category);
        }
    }
}

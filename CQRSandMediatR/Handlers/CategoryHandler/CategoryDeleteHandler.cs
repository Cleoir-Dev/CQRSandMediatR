using CQRSandMediatR.Commands.CategoryCommand.cs;
using CQRSandMediatR.Repositories.CategoryRepository;
using MediatR;

namespace CQRSandMediatR.Handlers.CategoryHandler
{
    public class CategoryDeleteHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryDeleteHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);
            if (category == null)
                return default;

            return await _categoryRepository.DeleteAsync(category.Id);
        }
    }
}

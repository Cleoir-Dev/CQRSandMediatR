using CQRSandMediatR.Commands.CategoryCommand.cs;
using CQRSandMediatR.Repositories.CategoryRepository;
using MediatR;

namespace CQRSandMediatR.Handlers.CategoryHandler
{
    public class CategoryUpdateHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryUpdateHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<int> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(command.Id);
            if (category == null)
                return default;

            category.Title = command.Title;

            return await _categoryRepository.UpdateAsync(category);
        }
    }
}

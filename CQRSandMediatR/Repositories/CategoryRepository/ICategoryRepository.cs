using CQRSandMediatR.Models;

namespace CQRSandMediatR.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> GetListAsync();
        public Task<CategoryModel> GetByIdAsync(Guid Id);
        public Task<int> AddAsync(CategoryModel category);
        public Task<int> UpdateAsync(CategoryModel category);
        public Task<int> DeleteAsync(Guid Id);
    }
}

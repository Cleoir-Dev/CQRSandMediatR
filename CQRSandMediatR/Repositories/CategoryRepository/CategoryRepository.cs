using CQRSandMediatR.Data;
using CQRSandMediatR.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSandMediatR.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbContextData _dbContext;

        public CategoryRepository(DbContextData dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(CategoryModel category)
        {
            _dbContext.Categories.Add(category);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            var filteredData = _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Categories.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<CategoryModel> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Categories.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<CategoryModel>> GetListAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<int> UpdateAsync(CategoryModel category)
        {
            _dbContext.Categories.Update(category);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

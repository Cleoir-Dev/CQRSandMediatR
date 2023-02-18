using CQRSandMediatR.Data;
using CQRSandMediatR.Model;
using Microsoft.EntityFrameworkCore;

namespace CQRSandMediatR.Repositories
{
    public class ContextRepository : IContextRepository
    {
        private readonly DbContextData _dbContext;

        public ContextRepository(DbContextData dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<DetailModel> AddAsync(DetailModel details)
        {
            var result = _dbContext.Details.Add(details);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            var filteredData = _dbContext.Details.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Details.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<DetailModel> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Details.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<DetailModel>> GetListAsync()
        {
            return await _dbContext.Details.ToListAsync();
        }

        public async Task<int> UpdateAsync(DetailModel details)
        {
            _dbContext.Details.Update(details);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

using CQRSandMediatR.Model;

namespace CQRSandMediatR.Repositories
{
    public interface IContextRepository
    {
        public Task<List<DetailModel>> GetListAsync();
        public Task<DetailModel> GetByIdAsync(Guid Id);
        public Task<DetailModel> AddAsync(DetailModel detail);
        public Task<int> UpdateAsync(DetailModel detail);
        public Task<int> DeleteAsync(Guid Id);
    }
}

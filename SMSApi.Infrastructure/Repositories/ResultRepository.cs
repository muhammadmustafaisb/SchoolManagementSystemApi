using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Infrastructure.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ApplicationDbContext _resultDbContext;

        public ResultRepository(ApplicationDbContext resultDbContext)
        {
            _resultDbContext = resultDbContext;
        }

        public async Task CreateResultAsync(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }

            await _resultDbContext.Results.AddAsync(result);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _resultDbContext.SaveChangesAsync() >= 0;
        }

        public void UpdateResult(Result result) { }

        public async Task DeleteResultAsync(Result result)
        {
            if (result == null)
            {
                throw new ArgumentNullException(nameof(result));
            }
            _resultDbContext.Results.Remove(result);
            await _resultDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Result>> GetAllResultsAsync()
        {
            return await _resultDbContext.Results.ToListAsync();
        }

        public async Task<Result> GetResultByIdAsync(int id)
        {
            return await _resultDbContext.Results.FirstOrDefaultAsync(p => p.ResId == id);
        }
    }
}

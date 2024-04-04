using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface IResultRepository
    {
        Task CreateResultAsync(Result result);
        Task<IEnumerable<Result>> GetAllResultsAsync();
        Task<Result> GetResultByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateResult(Result result);
        Task DeleteResultAsync(Result result);
    }
}

using SMSApi.Core.Models;

namespace SMSApi.Core.Repositories
{
    public interface IFeeRepository
    {
        Task CreateFeeAsync(Fee fee);
        Task<IEnumerable<Fee>> GetAllFeesAsync();
        Task<Fee> GetFeeByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        void UpdateFee(Fee fee);
        Task DeleteFeeAsync(Fee fee);
    }
}

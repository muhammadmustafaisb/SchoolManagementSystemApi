using Microsoft.EntityFrameworkCore;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Infrastructure.Repositories
{
    public class FeeRepository : IFeeRepository
    {
        private readonly ApplicationDbContext _feeDbContext;

        public FeeRepository(ApplicationDbContext feeDbContext)
        {
            _feeDbContext = feeDbContext;
        }
        public async Task CreateFeeAsync(Fee fee)
        {
            if (fee == null)
            {
                throw new ArgumentNullException(nameof(fee));
            }

            await _feeDbContext.Fees.AddAsync(fee);
        }

        public async Task DeleteFeeAsync(Fee fee)
        {
            if (fee == null)
            {
                throw new ArgumentNullException(nameof(fee));
            }
            _feeDbContext.Fees.Remove(fee);
            await _feeDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fee>> GetAllFeesAsync()
        {
            return await _feeDbContext.Fees.ToListAsync();
        }

        public async Task<Fee> GetFeeByIdAsync(int id)
        {
            return await _feeDbContext.Fees.FirstOrDefaultAsync(p => p.FeeId == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _feeDbContext.SaveChangesAsync() >= 0;
        }

        public void UpdateFee(Fee fee)
        {
        }
    }
}

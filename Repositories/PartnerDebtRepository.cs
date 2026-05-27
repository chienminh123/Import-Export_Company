using Import_Export_Company.Data;
using Import_Export_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Import_Export_Company.Repositories
{
    public class PartnerDebtRepository : IPartnerDebtRepository
    {
        private readonly AppDbContext _context;
        public PartnerDebtRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Partner_Debts>> GetAllAsync()
        {
            return await _context.PartnerDebts.ToListAsync();
        }

        public async Task<Partner_Debts> GetByPartnerAsync(string partnerType, int partnerId)
        {
            return await _context.PartnerDebts
                .FirstOrDefaultAsync(d => d.Partner_type == partnerType && d.Partner_id == partnerId);
        }

        public void Update(Partner_Debts debt)
        {
            _context.PartnerDebts.Update(debt);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

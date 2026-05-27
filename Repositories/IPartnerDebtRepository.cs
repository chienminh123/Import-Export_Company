using Import_Export_Company.Models;

namespace Import_Export_Company.Repositories
{
    public interface IPartnerDebtRepository
    {
        Task<IEnumerable<Partner_Debts>> GetAllAsync();
        Task<Partner_Debts> GetByPartnerAsync(string partnerType, int partnerId);
        void Update(Partner_Debts debt);
        Task SaveChangesAsync();
    }
}

using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;

namespace Import_Export_Company.Services
{
    public interface IPartnerDebtService
    {
        Task<IEnumerable<PartnerDebtDTO>> GetAllDebtsAsync();
        Task<PartnerDebtDTO> GetDebtByPartnerAsync(string partnerType, int partnerId);
        Task<PartnerDebtDTO> RecordPaymentAsync(MakePaymentDTO dto);
    }
}

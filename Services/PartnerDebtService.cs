using Import_Export_Company.DTOs.Request;
using Import_Export_Company.DTOs.Response;
using Import_Export_Company.Repositories;

namespace Import_Export_Company.Services
{
    public class PartnerDebtService : IPartnerDebtService
    {
        private readonly IPartnerDebtRepository _repository;
        public PartnerDebtService(IPartnerDebtRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<PartnerDebtDTO>> GetAllDebtsAsync()
        {
            var debts = await _repository.GetAllAsync();
            return debts.Select(d => new PartnerDebtDTO
            {
                Id = d.Id,
                Partner_type = d.Partner_type,
                Partner_id = d.Partner_id,
                Total_debt = d.Total_debt,
                Paid_amount = d.Paid_amount,
                Remaining_debt = d.Remaining_debt
            });
        }
        public async Task<PartnerDebtDTO> GetDebtByPartnerAsync(string partnerType, int partnerId)
        {
            var debt = await _repository.GetByPartnerAsync(partnerType, partnerId);
            if (debt == null) throw new Exception("DEBT_NOT_FOUND");
            return new PartnerDebtDTO
            {
                Id = debt.Id,
                Partner_type = debt.Partner_type,
                Partner_id = debt.Partner_id,
                Total_debt = debt.Total_debt,
                Paid_amount = debt.Paid_amount,
                Remaining_debt = debt.Remaining_debt
            };
        }
        public async Task<PartnerDebtDTO> RecordPaymentAsync(MakePaymentDTO dto)
        {
            var debt = await _repository.GetByPartnerAsync(dto.Partner_type, dto.Partner_id);
            if (debt == null) throw new Exception("DEBT_NOT_FOUND");
            if (dto.Amount > debt.Remaining_debt) throw new Exception("AMOUNT_EXCEEDS_DEBT");

            debt.Paid_amount += dto.Amount;
            debt.Remaining_debt = debt.Total_debt - debt.Paid_amount;
            _repository.Update(debt);
            await _repository.SaveChangesAsync();
            return new PartnerDebtDTO
            {
                Id = debt.Id,
                Partner_type = debt.Partner_type,
                Partner_id = debt.Partner_id,
                Total_debt = debt.Total_debt,
                Paid_amount = debt.Paid_amount,
                Remaining_debt = debt.Remaining_debt
            };
        }
    }
}

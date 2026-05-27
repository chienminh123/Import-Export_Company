using Import_Export_Company.DTOs.Request;
using Import_Export_Company.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Import_Export_Company.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerDebtsController : ControllerBase
    {
        private readonly IPartnerDebtService _debtService;
        public PartnerDebtsController(IPartnerDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDebts()
        {
            var debts = await _debtService.GetAllDebtsAsync();
            return Ok(debts);
        }

        [HttpGet("{partnerType}/{partnerId}")]
        public async Task<IActionResult> GetDebtByPartner(string partnerType, int partnerId)
        {
            try
            {
                var debt = await _debtService.GetDebtByPartnerAsync(partnerType, partnerId);
                return Ok(debt);
            }
            catch (Exception ex) when (ex.Message == "DEBT_NOT_FOUND")
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("pay")]
        public async Task<IActionResult> RecordPayment([FromBody] MakePaymentDTO dto)
        {
            try
            {
                var debt = await _debtService.RecordPaymentAsync(dto);
                return Ok(debt);
            }
            catch (Exception ex) when (ex.Message == "DEBT_NOT_FOUND")
            {
                return NotFound();
            }
            catch (Exception ex) when (ex.Message == "AMOUNT_EXCEEDS_DEBT")
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

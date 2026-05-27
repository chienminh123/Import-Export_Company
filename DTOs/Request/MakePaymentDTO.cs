using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs.Request
{
    public class MakePaymentDTO
    {
        [Required]
        public string Partner_type { get; set; }

        [Required]
        public int Partner_id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Financial_Vouchers")]
    public class Financial_Vouchers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Voucher_number { get; set; }
        [Required]
        public string Type { get; set; }
        public string Reference_type { get; set; }
        public int? Reference_id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Payment_method { get; set; }
        [Required]
        public DateTime Payment_date { get; set; }
        [Required]
        public int User_id { get; set; }

        [ForeignKey("User_id")]
        public Users User { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Partner_Debts")]
    public class Partner_Debts
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Partner_type { get; set; }
        [Required]
        public int Partner_id { get; set; }
        public decimal Total_debt { get; set; }
        public decimal Paid_amount { get; set; }
        public decimal Remaining_debt { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Sales_Orders")]
    public class Sales_Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string So_number { get; set; }
        [Required]
        public int Customer_id { get; set; }
        [Required]
        public DateTime Order_date { get; set; }
        [Required]
        public decimal Total_amount { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Created_by { get; set; }

        [ForeignKey("Customer_id")]
        public Customers Customer { get; set; }
        [ForeignKey("Created_by")]
        public Users User { get; set; }
        public ICollection<Sales_Order_Details> SalesOrderDetails { get; set; }
    }
}

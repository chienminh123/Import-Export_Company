using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Sales_Order_Details")]
    public class Sales_Order_Details
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Sales_Order_id { get; set; }
        [Required]
        public int Product_id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Unit_price { get; set; }

        [ForeignKey("Sales_Order_id")]
        public Sales_Orders Sales_order { get; set; }
        [ForeignKey("Product_id")]
        public Products Product { get; set; }
    }
}

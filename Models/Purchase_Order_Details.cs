using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Purchase_Order_Details")]
    public class Purchase_Order_Details
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Purchase_Order_id { get; set; }
        [Required]
        public int Product_id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Unit_price { get; set; }

        [ForeignKey("Purchase_Order_id")]
        public Purchase_Orders Purchase_Order { get; set; }
        [ForeignKey("Product_id")]
        public Products Product { get; set; }
    }
}

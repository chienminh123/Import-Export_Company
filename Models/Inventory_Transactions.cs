using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Inventory_Transactions")]
    public class Inventory_Transactions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Warehouse_id { get; set; }
        [Required]
        public int Product_id { get; set; }
        [Required]
        public string Transaction_type { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int? Reference_id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public DateTime Created_at { get; set; } = DateTime.Now;

        [ForeignKey("Warehouse_id")]
        public WareHouses WareHouse { get; set; }
        [ForeignKey("Product_id")]
        public Products Product { get; set; }
        [ForeignKey("User_id")]
        public Users User { get; set; }
    }
}

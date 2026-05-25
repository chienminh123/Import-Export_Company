using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Inventory")]
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int WareHouse_id { get; set; }
        [Required]
        public int Product_id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int Reserved_quantity { get; set; }

        [ForeignKey("WareHouse_id")]
        public WareHouses WareHouse { get; set; }
        [ForeignKey("Product_id")]
        public Products Product { get; set; }
    }
}

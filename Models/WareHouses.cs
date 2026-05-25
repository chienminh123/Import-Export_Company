using Import_Export_Company.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("WareHouses")]
    public class WareHouses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        [VNPhone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Inventory_Transactions> InventoryTransactions { get; set; }
        public ICollection<Inventory> Inventorys { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Sku { get; set; }
        public string Barcode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Unit { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Volume { get; set; }
        public string Description { get; set; }

        public ICollection<Inventory_Transactions> InventoryTransactions { get; set; }
        public ICollection<Inventory> Inventorys { get; set; }
        public ICollection<Purchase_Order_Details> PurchaseOrderDetails { get; set; }
        public ICollection<Sales_Order_Details> SalesOrderDetails { get; set; }
    }
}

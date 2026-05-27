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
        public string So_Number { get; set; }

        [Required]
        public int Customer_id { get; set; }

        [Required]
        public int Warehouse_id { get; set; }

        [Required]
        public DateTime Order_Date { get; set; } 

        [Required]
        public decimal Total_Amount { get; set; } 

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public int Created_by { get; set; }

        [ForeignKey("Customer_id")]
        public Customers Customer { get; set; }

        [ForeignKey("Warehouse_id")]
        public WareHouses WareHouse { get; set; }

        [ForeignKey("Created_by")]
        public Users User { get; set; }

        public ICollection<Sales_Order_Details> SalesOrderDetails { get; set; }
    }
}

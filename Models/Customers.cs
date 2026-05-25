using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Customer_name { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Delivery_address { get; set; }

        public ICollection<Sales_Orders> SalesOrders { get; set; }
    }
}

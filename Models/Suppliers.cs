using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Company_name { get; set; }
        [Required]
        public string Country { get; set; }
        public string Contact_name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

        public ICollection<Purchase_Orders> PurchaseOrders { get; set; }
    }
}

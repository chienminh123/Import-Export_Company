using Import_Export_Company.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("UserName")]
        public string UserName { get; set; }
        [Required]
        [Column("Password")]
        public string Password { get; set; }
        [Required]
        [Column("PhoneNumber")]
        [VNPhone]
        public string PhoneNumber { get; set; }
        [Required]
        [Column("Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Column("Full_name")]
        public string FullName { get; set; }
        [Required]
        [Column("Department")]
        public string Department { get; set; }
        [Required]
        [Column("Status")]
        public string Status { get; set; }
        [Required]
        [Column("Created_at")]
        public DateTime Created_at { get; set; } = DateTime.Now;

        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<Inventory_Transactions> InventoryTransactions { get; set; }
        public ICollection<Purchase_Orders> PurchaseOrders { get; set; }
        public ICollection<Sales_Orders> SalesOrders { get; set; }
        public ICollection<Financial_Vouchers> FinancialVouchers { get; set; }
    }
}

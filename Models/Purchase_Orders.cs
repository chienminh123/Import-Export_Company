using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Purchase_Orders")]
    public class Purchase_Orders
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Po_Number { get; set; }
        [Required]
        public int Supplier_id { get; set; }
        [Required]
        public DateTime Order_Date { get; set; }
        [Required]
        public DateTime Expected_Delivery { get; set; }
        [Required]
        public decimal Total_Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Created_by { get; set; }

        [ForeignKey("Supplier_id")]
        public Suppliers Supplier { get; set; }
        [ForeignKey("Created_by")]
        public Users User { get; set; }
        public ICollection<Purchase_Order_Details> PurchaseOrderDetails { get; set; }
        public ICollection<Import_Documents> ImportDocuments { get; set; }

    }
}

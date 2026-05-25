using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Import_Documents")]
    public class Import_Documents
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Purchase_Order_id { get; set; }
        [Required]
        public string Bill_of_lading { get; set; }
        [Required]
        public string Commercial_invoice { get; set; }
        [Required]
        public string Customs_declaration { get; set; }
        public DateTime? Etd { get; set; }
        public DateTime? Eta { get; set; }
        [Required]
        public string Document_url { get; set; }

        [ForeignKey("Purchase_Order_id")]
        public Purchase_Orders Purchase_Order { get; set; }
    }
}



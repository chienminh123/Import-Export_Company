using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs
{
    public class ProductDTO
    {
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

    }
}

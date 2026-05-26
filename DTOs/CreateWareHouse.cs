using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs
{
    public class CreateWareHouse
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
    }
}

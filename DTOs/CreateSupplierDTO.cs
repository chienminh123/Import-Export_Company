using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs
{
    public class CreateSupplierDTO
    {
        public string Company_name { get; set; }
        public string Country { get; set; }
        public string Contact_name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

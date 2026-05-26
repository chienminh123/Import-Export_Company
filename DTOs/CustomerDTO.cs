using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Customer_name { get; set; }
        public string Phone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Delivery_address { get; set; }
    }
}

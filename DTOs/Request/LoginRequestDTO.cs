using System.ComponentModel.DataAnnotations;

namespace Import_Export_Company.DTOs.Request
{
    public class LoginRequestDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Import_Export_Company.Models
{
    [Table("Roles")]
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Role_name { get; set; }
        public string Description { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}

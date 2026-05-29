namespace Import_Export_Company.DTOs.Response
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public List<string> Roles { get; set; }
    }
}

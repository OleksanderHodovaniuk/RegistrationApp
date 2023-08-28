#nullable disable

namespace RegistrationApp.Models.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
    }
}

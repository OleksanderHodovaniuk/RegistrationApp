#nullable disable

namespace RegistrationApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}

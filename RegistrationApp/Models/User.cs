using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public City? City { get; set; }

    }
}

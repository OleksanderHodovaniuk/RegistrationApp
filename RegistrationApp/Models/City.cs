using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrationApp.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<User>? Users { get; set; }
    }
}

using RegistrationApp.Models;
using RegistrationApp.Models.DTOs;

namespace RegistrationApp.Interfaces
{
    public interface IRegistrationService<M, R>
    {
        Task<R> Register(M model); 
        Task<ICollection<CountryDTO>> GetCountries();
        Task<ICollection<CityDTO>> GetCities(string country);
    }
}

using Microsoft.EntityFrameworkCore;
using RegistrationApp.Data;
using RegistrationApp.Models;
using RegistrationApp.Interfaces;
using RegistrationApp.Models.ViewModels;
using FluentValidation;
using FluentValidation.Results;
using RegistrationApp.Models.DTOs;

namespace RegistrationApp.Services
{
    public class RegistrationService : IRegistrationService<RegisterViewModel, ValidationResult>
    {
        private readonly AppDbContext context;
        private readonly IValidator<RegisterViewModel> validator;
        
        public RegistrationService(AppDbContext context, IValidator<RegisterViewModel> validator)
        {
            this.context = context;
            this.validator = validator;
        }

        //Create and add a new user to database.
        public async Task<ValidationResult> Register(RegisterViewModel model)
        {
            var validatorResult = validator.Validate(model);
            if (!validatorResult.IsValid)
                return validatorResult;

            validatorResult = await IsUnique(model);
            if (!validatorResult.IsValid)
                return validatorResult;

            User? user = await ViewModelToUser(model);
            if (user == null)
            {
                validatorResult.Errors.Add(new ValidationFailure() { PropertyName = "CountryCity", ErrorMessage = "Country-City error." });
                return validatorResult;
            }

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return validatorResult;
        }

        //Ceck if the user is unique.
        private async Task<ValidationResult> IsUnique(RegisterViewModel model)
        {
            var validationResult = new ValidationResult();

            if (await context.Users.AnyAsync(u => u.Name == model.Name))
                validationResult.Errors.Add(new ValidationFailure() { PropertyName = "Name", ErrorMessage = "This username is already in use." });
            
            if(await context.Users.AnyAsync(u => u.Email == model.Email))
                validationResult.Errors.Add(new ValidationFailure() { PropertyName = "Email", ErrorMessage = "This email is already in use." });

            if (await context.Users.AnyAsync(u => u.PhoneNumber == model.PhoneNumber))
                validationResult.Errors.Add(new ValidationFailure() { PropertyName = "PhoneNumber", ErrorMessage = "This phone number is already in use." });

            return validationResult;
        }

        //Create User object.
        private async Task<User?> ViewModelToUser(RegisterViewModel model)
        {
            Country? country = await context.Countries.FirstOrDefaultAsync(c => c.Name == model.Country);
            if (country != null)
            {
                City? city = await context.Cities.FirstOrDefaultAsync(c => c.Name == model.City && c.CountryId == country.Id);
                if (city != null)
                {
                    User user = new User()
                    {
                        Name = model.Name,
                        Age = model.Age,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Password = model.Password,
                        CountryId = country.Id,
                        Country = country,
                        CityId = city.Id,
                        City = city
                    };
                    return user;
                }
                return null;            
                
            }
            return null;
        }

        //Get all Countries.
        public async Task<ICollection<CountryDTO>> GetCountries()
        {
            var DTOs = new List<CountryDTO>();

            var countries = await context.Countries.ToListAsync();

            foreach (var c in countries)
            {
                DTOs.Add(CountryToDTO(c));
            }

            return DTOs = DTOs.OrderBy(c => c.Name).ToList();
        }

        //Create CountryDTO object.
        public CountryDTO CountryToDTO(Country country)
        {
            var dto = new CountryDTO() { Name = country.Name};

            return dto;
        }

        //Get all Cities.
        public async Task<ICollection<CityDTO>> GetCities(string countryName)
        {
            var DTOs = new List<CityDTO>();

            var country = await context.Countries.FirstOrDefaultAsync(c => c.Name == countryName);

            if (country != null)
            {
                var cities = await context.Cities.Where(c => c.CountryId == country.Id).ToListAsync();

                foreach (var c in cities)
                {
                    DTOs.Add(CityToDTO(c));
                }
            }
   
            return DTOs = DTOs.OrderBy(c => c.Name).ToList();
        }

        //Create CityDTO object.
        public CityDTO CityToDTO(City city) 
        {
            var dto = new CityDTO() {  Name = city.Name };

            return dto;
        }

    }
}


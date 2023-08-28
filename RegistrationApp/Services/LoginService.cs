using Microsoft.EntityFrameworkCore;
using RegistrationApp.Data;
using RegistrationApp.Interfaces;
using RegistrationApp.Models;
using RegistrationApp.Models.DTOs;
using RegistrationApp.Models.ViewModels;


namespace RegistrationApp.Services
{
    public class LoginService : ILoginService<LoginViewModel, UserDTO>
    {
        private readonly AppDbContext context;

        public LoginService(AppDbContext context)
        {
            this.context = context;
        }

        //Login user userDTO object. 
        public async Task<UserDTO?> Login(LoginViewModel model)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
            if (user != null)
            {
                var dto = await UserToDto(user);
                return dto;
            }

            return null;
        }

        //Create userDTO object.
        private async Task<UserDTO> UserToDto(User user)
        {
            Country country = await context.Countries.FirstAsync(c => c.Id == user.CountryId);
            City city = await context.Cities.FirstAsync(c => c.Id == user.CityId);

            var dto = new UserDTO() 
            {
                Name = user.Name,
                Age = user.Age,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = country.Name,
                City = city.Name,
                Password = user.Password
            };

            return dto;
        }

        //Get all users.
        public async Task<ICollection<UserDTO>> GetUsers()
        {
            var users = await context.Users.ToListAsync();

            var DTOs = new List<UserDTO>();

            foreach (var user in users) 
            {
                DTOs.Add(await UserToDto(user));
            }

            return DTOs;
        }


    }
}

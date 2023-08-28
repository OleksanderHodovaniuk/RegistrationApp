using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using RegistrationApp.Interfaces;
using RegistrationApp.Models;
using RegistrationApp.Models.DTOs;
using RegistrationApp.Models.ViewModels;

namespace RegistrationApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRegistrationService<RegisterViewModel, ValidationResult> registrationService;
        private readonly ILoginService<LoginViewModel, UserDTO> loginService;
        public UserController(IRegistrationService<RegisterViewModel, ValidationResult> registrationService, ILoginService<LoginViewModel, UserDTO> loginService)
        {
            this.registrationService = registrationService;
            this.loginService = loginService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterViewModel model) 
        {
            var validationResult = await registrationService.Register(model);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok("User successfully created.");
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await loginService.Login(model);
            if (user == null)
            {
                return BadRequest("Incorrect username or password.");
            }

            return Ok(user);
        }


        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetUsers()
        {
            return Ok(await loginService.GetUsers());
        }


        [HttpGet("countries")]
        public async Task<ActionResult<ICollection<CountryDTO>>> GetCountries()
        {
           return Ok(await registrationService.GetCountries());
        }

        [HttpGet("{country}")]
        public async Task<ActionResult<ICollection<CityDTO>>> GetCities(string country)
        {
            return Ok(await registrationService.GetCities(country));
        }
    }
}

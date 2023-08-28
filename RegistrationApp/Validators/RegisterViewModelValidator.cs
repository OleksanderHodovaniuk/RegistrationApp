using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RegistrationApp.Data;
using RegistrationApp.Models;
using RegistrationApp.Models.ViewModels;

namespace RegistrationApp.Validators
{
    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            RuleFor(u => u.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Length(6, 30)
                .Matches(@"^\w+$")
                .WithMessage("Only letters, digits, and underscore character are allowed.");

            RuleFor(u => u.Age)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Must(num => num >= 18 && num <= 130)
                .WithMessage("Must be from 18 to 130.");

            RuleFor(u => u.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Length(16,40)
                .Matches(@"^\w+@gmail\.com$")
                .WithMessage("Must consist of @gmail.com at the end, Only letters, digits, and underscore are allowed.");

            RuleFor(u => u.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Matches(@"^\+[0-9]{12}$")
                .WithMessage("Must consist of + at the beginning and 12 digits.");

            RuleFor(u => u.Password)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty()
                .Length(6, 30)
                .Matches(@"^\w+$")
                .WithMessage("Only letters, digits, and underscore are allowed.");

            RuleFor(u => u.ConfirmPassword)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .Equal(u => u.Password)
                .WithMessage("Passwords do not match.");

            RuleFor(u => u.Country)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("Is required.");

            RuleFor(u => u.City)
               .Cascade(CascadeMode.Stop)
               .NotNull()
               .NotEmpty()
               .WithMessage("Is required.");
        }
    }
}

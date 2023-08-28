using Microsoft.EntityFrameworkCore;
using RegistrationApp.Data;
using RegistrationApp.Interfaces;
using RegistrationApp.Services;
using RegistrationApp.Models.ViewModels;
using RegistrationApp.Models;
using FluentValidation;
using RegistrationApp.Validators;
using FluentValidation.Results;
using RegistrationApp.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//Add registration service.
builder.Services.AddScoped<IRegistrationService<RegisterViewModel, ValidationResult>, RegistrationService>();

//Add login resvice.
builder.Services.AddScoped<ILoginService<LoginViewModel, UserDTO>, LoginService>();

//Add validator.
builder.Services.AddScoped<IValidator<RegisterViewModel>, RegisterViewModelValidator>();

//Add connection string.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

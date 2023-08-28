using RegistrationApp.Models;
using RegistrationApp.Models.DTOs;

namespace RegistrationApp.Interfaces
{
    public interface ILoginService<M, R>
    {
        Task<R?> Login(M login);
        Task<ICollection<UserDTO>> GetUsers();
    }
}

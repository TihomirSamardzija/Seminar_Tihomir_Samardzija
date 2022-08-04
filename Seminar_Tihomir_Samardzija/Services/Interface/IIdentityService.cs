using Seminar_Tihomir_Samardzija.Models.Dbo;

namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface IIdentityService
    {
        Task CreateRoleAsync(string role);
        Task CreateUserAsync(ApplicationUser user, string password, string role);
    }
}
using System.Security.Claims;
using Seminar_Tihomir_Samardzija.Models.Binding;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Models.ViewModel;
namespace Seminar_Tihomir_Samardzija.Services.Interface
{
    public interface IUserSevice
    {
        Task<ApplicationUserViewModel> UpdateUser(UserAdminUpdateBinding model);
        Task DeleteUserAsync(string id);
        Task<ApplicationUserViewModel?> CreateUserAsync(UserAdminBinding model);
        Task<List<UserRolesViewModel>> GetUserRoles();
        Task<List<ApplicationUserViewModel>> GetUsers();
        Task<ApplicationUser?> CreateUserAsync(UserBinding model, string role);

        Task<string> GetToken(TokenLoginBinding model);
        Task<ApplicationUserViewModel> GetUser(string id);
        Task<ApplicationUserViewModel> GetUser(ClaimsPrincipal user);
    }
}

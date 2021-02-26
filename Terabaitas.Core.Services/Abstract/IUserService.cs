using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;
using Terabaitas.Core.Domain;

namespace Terabaitas.Core.Services.Abstract
{
    public interface IUserService
    {
        Task<User> GetCurrentUser(ClaimsPrincipal claims);
        Task<User> GetUserById(string id);
        Task<string> GetRole(ClaimsPrincipal claims);
        Task<bool> IsManager(ClaimsPrincipal claims);
        Task<bool> CreateUser(User ent, string pass, string role_name, ModelStateDictionary model_state);
        Task<bool> ChangePassword(string old_password, string new_password, ModelStateDictionary model_state, ClaimsPrincipal claims);
        Task<bool> Login(string name, string pass);
        Task<bool> Logout(ClaimsPrincipal claims);
        Task<bool> Edit(User user);
        Task<bool> RemoveUser(User user);
    }
}

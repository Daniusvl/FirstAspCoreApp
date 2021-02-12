using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;
using Terabaitas.Models;

namespace Terabaitas.Core
{
    public interface IAccountManager<TUser>
    {
        Task<TUser> GetCurrentUser(ClaimsPrincipal claims);
        Task<TUser> GetUser(string id);
        Task<string> GetRole(ClaimsPrincipal claims);
        Task<bool> IsManager(ClaimsPrincipal claims);
        Task<bool> CreateUser(User ent, string pass, string role_name, ModelStateDictionary model_state);
        Task<bool> ChangePassword(string old_password, string new_password, ModelStateDictionary model_state, ClaimsPrincipal claims);
        Task<bool> Login(string name, string pass);
        Task<bool> Logout(ClaimsPrincipal claims);
        void Edit(User user);
    }
}

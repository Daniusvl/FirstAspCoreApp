using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;
using Terabaitas.Core.Domain;
using Terabaitas.Core.Services.Abstract;

namespace Terabaitas.Core.Services
{
    public class UserService : IUserService
    {
        private UserManager<User> user_manager;
        private SignInManager<User> sign_in_manager;

        public UserService(UserManager<User> uManager, SignInManager<User> siManager)
        {
            user_manager = uManager;
            sign_in_manager = siManager;
        }

        public async Task<bool> ChangePassword(string old_password, string new_password, ModelStateDictionary model_state, ClaimsPrincipal claims)
        {
            User user = await GetCurrentUser(claims);

            var result = await user_manager.ChangePasswordAsync(user, old_password, new_password);

            if (!result.Succeeded)
            {
                model_state.AddModelError(string.Empty, "Old password is incorrect.");
                return false;
            }
            return true;
        }

        public async Task<bool> CreateUser(User user, string pass, string role_name, ModelStateDictionary model_state)
        {
            var ent = await user_manager.FindByNameAsync(user.UserName);

            if (ent != null)
            {
                model_state.AddModelError("UserName", "Account with this username already exists.");
                return false;
            }

            var result = await user_manager.CreateAsync(user, pass);

            if (!result.Succeeded)
                return false;

            result = await user_manager.AddToRoleAsync(user, role_name);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<bool> Edit(User user)
        {
            if (user is null)
                return false;

            var result = await user_manager.UpdateAsync(user);

            if (!result.Succeeded)
                return false;
            
            return true;
        }

        public async Task<User> GetCurrentUser(ClaimsPrincipal claims)
        {
            if (claims is null)
                return null;

            return await user_manager.GetUserAsync(claims);
        }

        public async Task<string> GetRole(ClaimsPrincipal claims)
        {
            User user = await GetCurrentUser(claims);

            if (user is null)
                return string.Empty;

            var roles = await user_manager.GetRolesAsync(user);

            if (roles.Count == 1)
                return roles[0];

            return string.Empty;
        }

        public async Task<User> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            return await user_manager.FindByIdAsync(id);
        }

        public async Task<bool> IsManager(ClaimsPrincipal claims)
        {
            string role = await GetRole(claims);

            return role == "Manager";
        }

        public async Task<bool> Login(string name, string pass)
        {
            var user = await user_manager.FindByNameAsync(name);

            if (user is null)
                return false;

            var result = await sign_in_manager.PasswordSignInAsync(user, pass, false, false);

            if (!result.Succeeded)
                return false;

            return true;
        }

        public async Task<bool> Logout(ClaimsPrincipal claims)
        {
            if (claims is null)
                return false;

            if (!claims.Identity.IsAuthenticated)
                return false;

            await sign_in_manager.SignOutAsync();

            return true;
        }

        public async Task<bool> RemoveUser(User user)
        {
            if (user is null)
                return false;

            await user_manager.DeleteAsync(user);
            return true;
        }
    }
}

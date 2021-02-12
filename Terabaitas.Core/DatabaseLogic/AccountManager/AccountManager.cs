using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Terabaitas.Data;
using Terabaitas.Models;

namespace Terabaitas.Core
{
    public class AccountManager : IAccountManager<User>
    {
        private UserManager<User> user_manager;
        private SignInManager<User> sign_in_manager;
        private AppDbContext app_context;

        public AccountManager(UserManager<User> uManager, SignInManager<User> siManager, AppDbContext dbcontext)
        {
            user_manager = uManager;
            sign_in_manager = siManager;
            app_context = dbcontext;
        }

        public async Task<bool> CreateUser(User user, string pass, string role_name, ModelStateDictionary model_state)
        {
            var ent = await user_manager.FindByNameAsync(user.UserName);

            if (ent != null)
            {
                model_state.AddModelError("UserName", "Account with this username already exists.");
                return false;
            }

            ent = Get(user.PhoneNumber);

            if (ent != null)
            {
                model_state.AddModelError("PhoneNumber", "Account with this phone number already exists");
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

        public async void Edit(User user)
        {
            if (user is null)
                return;

            await user_manager.UpdateAsync(user);
        }

        public async Task<User> GetCurrentUser(ClaimsPrincipal claims)
        {
            if (claims is null)
                return null;

            return await user_manager.GetUserAsync(claims);
        }

        public User Get(string phone_num)
        {
            return app_context.Users.FirstOrDefault(user => user.PhoneNumber == phone_num);
        }

        public async Task<User> GetUser(string id)
        {
            if (id is null || id == string.Empty)
                return null;

            return await user_manager.FindByIdAsync(id.ToString());
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

        public async void Remove(User user)
        {
            if (user is null)
                return;

            await user_manager.DeleteAsync(user);
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

        public async Task<string> GetRole(ClaimsPrincipal claims)
        {
            User user = await GetCurrentUser(claims);
            if (user is null)
                return string.Empty;
            var roles = await user_manager.GetRolesAsync(user);
            if (roles.Count == 1)
                return roles[0];
            return string.Empty ;
        }

        public async Task<bool> IsManager(ClaimsPrincipal claims)
        {
            string role = await GetRole(claims);

            return role == "Manager";
        }
    }
}

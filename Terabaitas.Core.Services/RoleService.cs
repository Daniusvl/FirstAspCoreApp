﻿using Microsoft.AspNetCore.Identity;
using Terabaitas.Core.Services.Abstract;

namespace Terabaitas.Core.Services
{
    public class RoleService : IRoleService
    {
        private RoleManager<IdentityRole> role_manager;

        public RoleService(RoleManager<IdentityRole> rManager)
        {
            role_manager = rManager;
        }

        public async void Add(string role_name)
        {
            bool exists = await role_manager.RoleExistsAsync(role_name);

            if (exists)
                return;

            var role = new IdentityRole() { Name = role_name };

            await role_manager.CreateAsync(role);
        }

        public async void Remove(string role_name)
        {
            bool exists = await role_manager.RoleExistsAsync(role_name);

            if (!exists)
                return;

            var role = await role_manager.FindByNameAsync(role_name);

            if (role is null)
                return;

            await role_manager.DeleteAsync(role);

        }
    }
}

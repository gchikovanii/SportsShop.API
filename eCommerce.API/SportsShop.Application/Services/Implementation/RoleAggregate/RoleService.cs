using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Constants;
using SportsShop.Application.Services.Abstraction.RoleAggregate;
using SportsShop.Domain.Entities.UserAggregte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Services.Implementation.RoleAggregate
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleService(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateRoleAsync(RoleType role)
        {
            var roleExists = await _roleManager.FindByNameAsync(role.ToString());
            if (roleExists == null)
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = role.ToString()
                });
                return IdentityResult.Success;
            }
            else
            {
                return IdentityResult.Failed(new IdentityError() { Description = "Role Already Exists!" });
            }
        }
        public async Task<List<AppRole>> GetRolesAsync()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }


    }
}

using Microsoft.AspNetCore.Identity;
using SportsShop.Application.Constants;
using SportsShop.Domain.Entities.UserAggregte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Services.Abstraction.RoleAggregate
{
    public interface IRoleService
    {
        Task<IdentityResult> CreateRoleAsync(RoleType role);
        Task<List<AppRole>> GetRolesAsync();
    }
}

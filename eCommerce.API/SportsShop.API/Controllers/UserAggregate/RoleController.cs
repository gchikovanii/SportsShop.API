using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsShop.API.Constants;
using SportsShop.Application.Constants;
using SportsShop.Application.Services.Abstraction.RoleAggregate;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.UserAggregate
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpGet]

        public async Task<IActionResult> GetRoles()
        {
            return Ok(await _roleService.GetRolesAsync());
        }
        [Authorize(Roles = UserType.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateRoles([FromForm] RoleType role)
        {
            return Ok(await _roleService.CreateRoleAsync(role));
        }


    }
}

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsShop.API.Constants;
using SportsShop.Application.Command.UserAggregate;
using SportsShop.Application.Command.UserAggregate.PrivilgedUser;
using SportsShop.Application.Quries.UserAggregate;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.UserAggregate
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpGet(nameof(GetUsersById))]
        public async Task<IActionResult> GetUsersById([FromQuery] GetUserByIdQuery input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _mediator.Send(new GetUsersQuery()));
        }
        [Authorize(Roles = UserType.Admin)]

        [HttpPost(nameof(CreateAdmin))]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.AdminUser)]

        [HttpPut(nameof(UpdateUserInfoCommand))]

        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfoCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.AdminUser)]

        [HttpPut(nameof(ResetPassword))]

        public async Task<IActionResult> ResetPassword(ResetPasswordCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.AdminUser)]

        [HttpDelete]

        public async Task<IActionResult> DeleteUser(DeleteUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using SportsShop.Application.Command.UserAggregate.Account;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.UserAggregate
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Registration))]
        public async Task<IActionResult> Registration(CreateUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

        [HttpPost(nameof(LogIn))]
        public async Task<IActionResult> LogIn(SignInUserCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

    }
}

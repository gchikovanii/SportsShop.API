using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using SportsShop.API.Constants;
using SportsShop.Application.Command.AddressAggregate;
using SportsShop.Application.Quries.UserAggregate.AddressAggregate;
using System.Threading.Tasks;

namespace SportsShop.API.Controllers.UserAggregate
{
    public class AddressController : BaseController
    {
        private readonly IMediator _mediator;
        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize(Roles = UserType.User)]
        [HttpGet]
        public async Task<IActionResult> GetUserAddress([FromQuery]GetUserAddressQuery input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.User)]
        [HttpPost]
        public async Task<IActionResult> SaveUserAddress(SaveUserAddressCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.User)]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAddress(UpdateUserAddressCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [Authorize(Roles = UserType.User)]
        [HttpDelete]
        public async Task<IActionResult> SaveUserAddress(DeleteUserAddressCommand input)
        {
            return Ok(await _mediator.Send(input));
        }

    }
}

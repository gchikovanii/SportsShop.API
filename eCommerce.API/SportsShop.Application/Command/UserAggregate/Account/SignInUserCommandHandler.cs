using MediatR;
using Microsoft.AspNetCore.Identity;
using SportsShop.Application.Services.Abstraction.JwtAuth;
using SportsShop.Domain.Entities.UserAggregte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.UserAggregate.Account
{
    public class SignInUserCommandHandler : IRequestHandler<SignInUserCommand, string>
    {
        private readonly IJwtAuthenticationManager _jwtAuthentication;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public SignInUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtAuthenticationManager jwtAuthentication)
        {
            _jwtAuthentication = jwtAuthentication;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<string> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);
            var roles = await _userManager.GetRolesAsync(user);
            return _jwtAuthentication.Authenticate(checkPassword.Succeeded, request.Email, roles.ToList());
           
        }
    }
}

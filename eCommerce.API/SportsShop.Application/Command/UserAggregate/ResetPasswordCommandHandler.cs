using MediatR;
using Microsoft.AspNetCore.Identity;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SportsShop.Application.Command.UserAggregate
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public ResetPasswordCommandHandler(IUserRepository userRepository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _signInManager = signInManager;
        }
        public async Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            var checkPassword = await _signInManager.PasswordSignInAsync(user, request.Password, true, false);

            if (checkPassword.Succeeded)
            {
                await _userManager.ChangePasswordAsync(user, request.Password, request.NewPassword);
                await _userRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
           
        }
    }
}

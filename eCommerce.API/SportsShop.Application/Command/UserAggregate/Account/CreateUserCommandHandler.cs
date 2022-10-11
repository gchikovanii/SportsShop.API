using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Constants;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.UserAggregate.Account
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        public CreateUserCommandHandler(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEmailExists = await _userManager.FindByEmailAsync(request.Email);
            var userNameExists = await _userRepository.GetQuery(i => i.UserName == request.UserName).FirstOrDefaultAsync();
            if (userEmailExists == null && userNameExists == null)
            {
                var user = new AppUser()
                {
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    DOB = request.DOB
                };
                var userCreated = await _userManager.CreateAsync(user, request.Password);
                if (userCreated.Succeeded)
                    await _userManager.AddToRoleAsync(user, RoleType.User.ToString());
                return true;
            }
            else
                return false;
        }
    }
}

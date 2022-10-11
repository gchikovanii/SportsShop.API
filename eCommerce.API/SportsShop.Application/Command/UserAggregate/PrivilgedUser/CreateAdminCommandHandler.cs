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

namespace SportsShop.Application.Command.UserAggregate.PrivilgedUser
{
    public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        public CreateAdminCommandHandler(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<bool> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var adminExists = await _userRepository.GetQuery(i => i.Email == request.Email).FirstOrDefaultAsync();
            if (adminExists == null)
            {
                var admin = new AppUser()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };
                var adminCreated = await _userManager.CreateAsync(admin, request.Password);
                if (adminCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, RoleType.Admin.ToString());
                    return true;
                }
            }
            return false;
        }
    }
}

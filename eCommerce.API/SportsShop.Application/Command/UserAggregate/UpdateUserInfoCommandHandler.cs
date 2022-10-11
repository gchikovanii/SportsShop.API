using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.UserAggregate
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        public UpdateUserInfoCommandHandler(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public async Task<bool> Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null)
            {
                if (request.FirstName != null)
                    user.FirstName = request.FirstName;
                if (request.LastName != null)
                    user.LastName = request.LastName;
                if (request.DOB.Year != 0 && request.DOB.Month != 0 && request.DOB.Day != 0)
                    user.DOB = request.DOB;
                if (request.PhoneNumber != null)
                    user.PhoneNumber = request.PhoneNumber;
                if (request.UserName != null)
                {
                    var checkUserName = await _userRepository.GetQuery(i => i.UserName == request.UserName).FirstOrDefaultAsync();
                    if(checkUserName == null)
                    {
                        user.UserName = request.UserName;
                    }
                }
                _userRepository.Update(user);
                return true;
            }
            return false;
        }
    }
}

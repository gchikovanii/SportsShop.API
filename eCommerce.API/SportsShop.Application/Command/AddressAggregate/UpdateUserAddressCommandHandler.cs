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

namespace SportsShop.Application.Command.AddressAggregate
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public UpdateUserAddressCommandHandler(IAddressRepository addressRepository, UserManager<AppUser> user)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(UpdateUserAddressCommand request, CancellationToken cancellationToken)
        {
            var order = await _addressRepository.GetQuery(i => i.Id == request.OrderId).FirstOrDefaultAsync();
            if(order != null)
            {
                if (request.City != null)
                    order.City = request.City;
                if (request.State != null)
                    order.State = request.State;
                if (request.Street != null)
                    order.Street = request.Street;
                if (request.ZipCode != null)
                    order.ZipCode = request.ZipCode;
                _addressRepository.Update(order);
                return await _addressRepository.SaveChangesAsync();
            }
            return false;
               
           
        }
    }
}

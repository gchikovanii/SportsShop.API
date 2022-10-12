using MediatR;
using Microsoft.AspNetCore.Identity;
using SportsShop.Application.Models;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Domain.Entities.UserAggregte.Details;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.AddressAggregate
{
    public class SaveUserAddressCommandHandler : IRequestHandler<SaveUserAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public SaveUserAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<bool> Handle(SaveUserAddressCommand request, CancellationToken cancellationToken)
        {
            var address = new Address()
            {
                City = request.City,
                State = request.State,
                Street = request.Street,
                ZipCode = request.ZipCode,
                UserId = request.UserId
            };
            await _addressRepository.CreateAsync(address);
            return await _addressRepository.SaveChangesAsync();

        }
    }
}

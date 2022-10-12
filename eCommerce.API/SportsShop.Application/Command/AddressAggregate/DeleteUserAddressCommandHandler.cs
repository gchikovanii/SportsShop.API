using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.AddressAggregate
{
    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;
        public DeleteUserAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var order = await _addressRepository.GetQuery(i => i.Id == request.OrderId).FirstOrDefaultAsync();
            if(order != null)
            {
                _addressRepository.Delete(order);
                return await _addressRepository.SaveChangesAsync();
            }
            return false;
               
        }
    }
}

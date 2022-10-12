using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Models;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Quries.UserAggregate.AddressAggregate
{
    public class GetUserAddressQueryHandler : IRequestHandler<GetUserAddressQuery, AddressDto>
    {
        private readonly IAddressRepository _addressRepository;
        public GetUserAddressQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<AddressDto> Handle(GetUserAddressQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetQuery(i => i.Id == request.AddressId).FirstOrDefaultAsync();
            if(address != null)
            {
                return new AddressDto()
                {
                    City = address.City,
                    Street = address.Street,
                    State = address.State,
                    ZipCode = address.ZipCode
                };
            }
            return null;
            
            
        }
    }
}

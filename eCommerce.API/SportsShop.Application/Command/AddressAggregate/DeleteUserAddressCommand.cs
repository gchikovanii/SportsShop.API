using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.AddressAggregate
{
    public class DeleteUserAddressCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
    }
}

using SportsShop.Domain.Entities.UserAggregte.Details;
using SportsShop.Infrastructure.DataContext;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Infrastructure.Repositories.Implementation
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using SportsShop.Domain.Entities.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Entities.UserAggregte.Details
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int UserId { get; set; }
        public AppUser User { get; set; }

    }
}

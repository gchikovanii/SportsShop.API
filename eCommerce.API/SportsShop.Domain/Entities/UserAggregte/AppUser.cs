using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SportsShop.Domain.Entities.UserAggregte.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Entities.UserAggregte
{
    public class AppUser : IdentityUser<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
        public Address Address { get; set; }
        public DateTime DOB { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

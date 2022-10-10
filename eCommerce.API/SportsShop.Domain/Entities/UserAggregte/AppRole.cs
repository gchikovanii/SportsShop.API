﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Domain.Entities.UserAggregte
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}

﻿using SportsShop.Domain.Entities.UserAggregte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Infrastructure.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<AppUser>
    {
    }
}

using MediatR;
using SportsShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Quries.UserAggregate
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
    }
}

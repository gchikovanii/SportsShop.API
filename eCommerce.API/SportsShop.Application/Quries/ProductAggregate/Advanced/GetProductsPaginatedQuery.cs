using MediatR;
using SportsShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Quries.ProductAggregate.Advanced
{
    public class GetProductsPaginatedQuery : IRequest<List<ProductDto>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

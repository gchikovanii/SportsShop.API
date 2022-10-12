using MediatR;
using SportsShop.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Quries.ProductAggregate.Advanced
{
    public class GetFilteredProductQuery : IRequest<List<ProductDto>>
    {
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}

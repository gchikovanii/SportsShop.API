using MediatR;
using SportsShop.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public string ProductName { get; set; }
        public string ShortTitle { get; set; }
        public string Description { get; set; }
        [Required]

        public decimal Price { get; set; }
        public string Brand { get; set; }
        [Required]
        public Types Types { get; set; }
    }
}

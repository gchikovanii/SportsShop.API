using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate.ProductImages
{
    public class DeleteImageCommand : IRequest<bool>
    {
        public int ProductImageId { get; set; }
    }
}

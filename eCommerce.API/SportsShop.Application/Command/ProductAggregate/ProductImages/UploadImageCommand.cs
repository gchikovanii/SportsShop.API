using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate.ProductImages
{
    public class UploadImageCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public IFormFile File { get; set; }
    }
}

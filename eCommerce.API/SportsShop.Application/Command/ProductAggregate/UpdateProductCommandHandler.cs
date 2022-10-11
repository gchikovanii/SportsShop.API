using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetQuery(I => I.ProductName == request.ProductName).FirstOrDefaultAsync();
            if (productExists != null)
            {
                if (request.ProductName != null)
                    productExists.ProductName = request.ProductName;
                if (request.Description != null)
                    productExists.Description = request.Description;
                if (request.ShortTitle != null)
                    productExists.ShortTitle = request.ShortTitle;
                if (request.Brand != null)
                    productExists.Brand = request.Brand;
                if (request.Price != 0)
                    productExists.Price = request.Price;
                productExists.Types = request.Types;
                return await _productRepository.SaveChangesAsync();
            }
            else
                return false;
        }
    }
}

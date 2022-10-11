using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Domain.Entities.ProductAggregate;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate
{
    public class UploadProductCommandHandler : IRequestHandler<UploadProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UploadProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UploadProductCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetQuery(i => i.ProductName == request.ProductName).FirstOrDefaultAsync();
            if(productExists == null)
            {
                var product = new Product()
                {
                    ProductName = request.ProductName,
                    ShortTitle = request.ShortTitle,
                    Brand = request.Brand,
                    Description = request.Description,
                    Price = request.Price,
                    Types = request.Types
                };
                await _productRepository.CreateAsync(product);
            }
            return await _productRepository.SaveChangesAsync();
        }
    }
}

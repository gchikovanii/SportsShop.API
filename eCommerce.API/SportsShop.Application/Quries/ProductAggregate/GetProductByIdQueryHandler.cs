using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Models;
using SportsShop.Domain.Entities.ProductAggregate;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Quries.ProductAggregate
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetQuery(i => i.Id == request.ProductId).Include(i => i.Images).FirstOrDefaultAsync();
            return new ProductDto()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ShortTitle = product.ShortTitle,
                Description = product.Description,
                Brand = product.Brand,
                Types = product.Types,
                Price = product.Price,
                Quantity = product.Quantity,
                Images = product.Images.Select(i => new ProductImage()
                {
                    PublicId = i.PublicId,
                    Url = i.Url
                }).ToList()
            };
        }
    }
}

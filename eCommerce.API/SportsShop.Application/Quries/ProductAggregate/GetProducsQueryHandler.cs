﻿using MediatR;
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
    public class GetProducsQueryHandler : IRequestHandler<GetProducsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProducsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        async Task<List<ProductDto>> IRequestHandler<GetProducsQuery, List<ProductDto>>.Handle(GetProducsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetQuery().Include(i => i.Images).ToListAsync();
            return products?.Select(product => new ProductDto()
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
            }).ToList();
        }
    }
}

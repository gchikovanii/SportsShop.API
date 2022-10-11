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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetQuery(i => i.Id == request.ProductId).FirstOrDefaultAsync();
            if(product != null)
            {
                _productRepository.Delete(product);
                return await _productRepository.SaveChangesAsync();
            }
            return false;
        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Filters;
using SportsShop.Application.Services.Abstraction.MediaAggregate;
using SportsShop.Domain.Entities.ProductAggregate;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate.ProductImages
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, bool>
    {

        private readonly ICloudinaryService _cloudinaryService;
        private readonly IProductImageRepository _productRepository;

        public UploadImageCommandHandler(ICloudinaryService cloudinaryService, IProductImageRepository productRepository)
        {
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<bool> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetQuery(i => i.Id == request.ProductId).FirstOrDefaultAsync();
            var uplaodImage = await _cloudinaryService.UploadImage(request.File);
            await _productRepository.CreateAsync(new ProductImage()
            {
                PublicId = uplaodImage.PublicId,
                Url = uplaodImage.Url.AbsoluteUri,
                ProductId = request.ProductId
            });
            var result = await _productRepository.SaveChangesAsync();
            if(uplaodImage == null)
            {
                throw new ImageNotUploadedException("Failed to upload image!" + (result == true ? "Image added to database" : "Failed to add to database"));
            }
            return result;
        }
    }
}

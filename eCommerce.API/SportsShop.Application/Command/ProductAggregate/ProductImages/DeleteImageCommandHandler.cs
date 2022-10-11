using MediatR;
using Microsoft.EntityFrameworkCore;
using SportsShop.Application.Filters;
using SportsShop.Application.Services.Abstraction.MediaAggregate;
using SportsShop.Infrastructure.Repositories.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SportsShop.Application.Command.ProductAggregate.ProductImages
{
    public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, bool>
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IProductImageRepository _productImageRepository;

        public DeleteImageCommandHandler(ICloudinaryService cloudinaryService, IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<bool> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _productImageRepository.GetQuery(i => i.Id == request.ProductImageId).FirstOrDefaultAsync();
            var deleteImage = await _cloudinaryService.DeleteImage(productImage.PublicId);
            var result = await _productImageRepository.SaveChangesAsync();
            if (deleteImage == null)
            {
                throw new ImageNotDeletedException("Failed to delete from cloudinary" + (result == true ? "Image Deleted from database": "Failed to delete from database"));
            }
            return result;
        }
    }
}

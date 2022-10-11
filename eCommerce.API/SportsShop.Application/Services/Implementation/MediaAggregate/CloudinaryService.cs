using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SportsShop.Application.ConfigurationOptions;
using SportsShop.Application.Services.Abstraction.MediaAggregate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Application.Services.Implementation.MediaAggregate
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySetting> cloudinarySettings)
        {
            var setting = cloudinarySettings.Value;
            var account = new Account() { ApiKey = setting.ApiKey, ApiSecret = setting.ApiSecret, Cloud = setting.Cloud };
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadImage(IFormFile file)
        {
            var result = new ImageUploadResult();
            if(result != null)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams() { File = new FileDescription(file.FileName,stream) };
                result = await _cloudinary.UploadAsync(uploadParams);
            }
            return result;
        }

        public async Task<DeletionResult> DeleteImage(string publicKey)
        {
            var result = await _cloudinary.DestroyAsync(new DeletionParams(publicKey));
            return result;
        }


    }
}

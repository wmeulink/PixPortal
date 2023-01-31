using Microsoft.AspNetCore.Http;
using PixPortal.DTOs.Requests;
using PixPortal.DTOs.Responses;
using PixPortal.Models;
using PixPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRespository;
        public ImageService(IImageRepository imageRepository)
        {
            _imageRespository = imageRepository;
        }

        public async Task<ImageUploadResponse> UploadImage(ImageUploadRequest imageUploadRequest)
        {
            var image = new Image
            {
                UserId = imageUploadRequest.UserId,
                Name = imageUploadRequest.Image.Name,
                Content = await GetByteArrayFromFile(imageUploadRequest.Image),

            };

            await _imageRespository.AddImage(image);

            return new ImageUploadResponse
            {
                ImageId = image.ImageId
            };
        }

        private static async Task<byte[]> GetByteArrayFromFile(IFormFile file)
        {
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                return stream.ToArray();
            }
        }
    }
}

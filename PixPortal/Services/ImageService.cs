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

        public async Task<ImageUploadResponseDTO> UploadImage(ImageUploadRequest imageUploadRequest)
        {
            var image = new Image
            {
                UserId = imageUploadRequest.UserId,
                Name = imageUploadRequest.Image.Name,
                Content = await GetByteArrayFromFile(imageUploadRequest.Image),

            };

            await _imageRespository.AddImage(image);

            return new ImageUploadResponseDTO
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

        private string GetContentType(string fileName)
        {
            var extension = Path.GetExtension(fileName).ToLowerInvariant();
            switch (extension)
            {
                case ".jpeg":
                case ".jpg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                default:
                    return "application/octet-stream";
            }
        }

        public async Task<ImageResponseDTO> GetImage(int userId, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Filename cannot be empty");
            }

            var image = await _imageRespository.GetImage(userId, fileName);

            if (image == null)
            {
                throw new ArgumentException("Image was not found");
            }

            return new ImageResponseDTO
            {
                Content = image.Content,
                ContentType = GetContentType(fileName),
                Name = image.Name,
            };
        }
    }
}

using PixPortal.DTOs.Requests;
using PixPortal.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Services.Interfaces
{
    public interface IImageService
    {
        Task<ImageUploadResponseDTO> UploadImage(ImageUploadRequest imageUploadRequest);
        Task<ImageResponseDTO> GetImage(string userId, string fileName);
        Task<List<ImageResponseDTO>> GetImagesByUserId(string userId);
    }
}

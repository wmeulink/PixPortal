using PixPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Services.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> GetImageById(int imageId);
        Task<IEnumerable<Image>> GetImagesByUserId(int userId);
        Task<Image> GetSharedImagesByUserId(int userId);
        Task<Image> AddImage(Image image);
        Task<Image> StarredImage(int imageId);
        Task DeleteImage(int imageId);
    }
}

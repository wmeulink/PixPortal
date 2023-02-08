using PixPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Services.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> GetImage(string userId, string fileName);
        Task<IEnumerable<Image>> GetImagesByUserId(string userId);
        Task<Image> GetSharedImagesByUserId(string userId);
        Task<Image> AddImage(Image image);
        Task<Image> StarredImage(int imageId);
        Task DeleteImage(int imageId);
    }
}

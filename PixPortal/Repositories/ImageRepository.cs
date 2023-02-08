using Microsoft.EntityFrameworkCore;
using PixPortal.Models;
using PixPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Services
{
    public class ImageRepository : IImageRepository
    {
        private ImageDbContext _imageDbContext;
        public ImageRepository(ImageDbContext imageDbContext)
        {
            _imageDbContext = imageDbContext;
        }

        public async Task<Image> AddImage(Image image)
        {
            _imageDbContext.Add(image);
            await _imageDbContext.SaveChangesAsync();
            return image;
        }

        public Task DeleteImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public async Task<Image> GetImage(string userId, string fileName)
        {
            return await _imageDbContext.Images.FirstOrDefaultAsync(i => i.UserId == userId && i.Name == fileName);
        }

        public Task<IEnumerable<Image>> GetImagesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetSharedImagesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> StarredImage(int imageId)
        {
            throw new NotImplementedException();
        }
    }
}

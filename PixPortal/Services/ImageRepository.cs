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

        public Task<Image> AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public Task DeleteImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetImageById(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Image>> GetImagesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> GetSharedImagesByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Image> StarredImage(int imageId)
        {
            throw new NotImplementedException();
        }
    }
}

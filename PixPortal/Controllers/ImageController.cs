using Microsoft.AspNetCore.Mvc;
using PixPortal.Models;
using PixPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Image>> GetImageById(int id)
        {
            var image = await _imageRepository.GetImageById(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> PostImage(Image image)
        {
            var newImage = await _imageRepository.AddImage(image);
            return CreatedAtAction(nameof(GetImageById), new { id = newImage.Id }, newImage);
        }
    }
}

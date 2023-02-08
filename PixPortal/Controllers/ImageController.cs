using Microsoft.AspNetCore.Mvc;
using PixPortal.DTOs.Requests;
using PixPortal.Models;
using PixPortal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PixPortal.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet("{userId}/{fileName}")]
        public async Task<IActionResult> GetImageById(string userId, string fileName)
        {
                var image = await _imageService.GetImage(userId, fileName);
                return File(image.Content, image.ContentType);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetImagesByUserId(string userId)
        {
            var images = await _imageService.GetImagesByUserId(userId);
            return Ok(images);
        }

        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage([FromForm] ImageUploadRequest imageUploadRequest)
        {
            var response = await _imageService.UploadImage(imageUploadRequest);
            //return CreatedAtAction(nameof(GetImageById), new { id = response.Id }, response);
            return Ok(response);
        }
    }
}

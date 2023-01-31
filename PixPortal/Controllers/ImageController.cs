using Microsoft.AspNetCore.Mvc;
using PixPortal.DTOs.Requests;
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
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        //[HttpGet]
        //public async Task<ActionResult<Image>> GetImageById(int id)
        //{
        //    var image = await _imageService.GetImageById(id);

        //    if (image == null)
        //    {
        //        return NotFound();
        //    }

        //    return image;
        //}

        [HttpPost]
        public async Task<ActionResult<Image>> UploadImage([FromForm] ImageUploadRequest imageUploadRequest)
        {
            var response = await _imageService.UploadImage(imageUploadRequest);
            //return CreatedAtAction(nameof(GetImageById), new { id = response.Id }, response);
            return Ok(response);
        }
    }
}

using Business.Commerce.Abstract;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        

        public ImageController(IImageService _imageService)
        {
            this._imageService = _imageService;
            
        }

        [HttpPost("Upload-File")]
        public async Task<IActionResult> UploadFile( IFormFile formFile, int goodsId)
            {
            var result = await _imageService.UploadFile(formFile,goodsId);
            if (result != null)
            {
                return Ok(result);
            }
            return null;
        }
        [HttpGet("ImageDelete {id}")]
        public async Task<IActionResult> ImageDelete(int id) 
        {
           var result =await _imageService.DeleteImage(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }



    }
}

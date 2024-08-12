using Business.Commerce.Abstract;
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

        [HttpPost("Upload-Fileasx")]
        public async Task<IActionResult> UploadFile([FromBody]Image image, IFormFile formFile)
        {
            var result = await _imageService.UploadFile(image, formFile);
            return Ok(result);
        }

    }
}

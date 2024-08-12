using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;
        public ImageManager(IImageDal _imageDal)
        {
            this._imageDal = _imageDal;
        }

        public async Task<Image> UploadFile(Image image, IFormFile formFile)
        {
           var result = await _imageDal.Upload(image, formFile);
            return result;
        }
    }
}

using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<EntityCommerce.Image> DeleteImage(int imageId)
        {
            var result =await _imageDal.DeleteImage(imageId);
            return result;  
        }

        public async Task<EntityCommerce.Image> UploadFile(IFormFile formFile, int goodsId)
        {
           var result = await _imageDal.Upload(formFile, goodsId);
            return result;
        }
    }
}

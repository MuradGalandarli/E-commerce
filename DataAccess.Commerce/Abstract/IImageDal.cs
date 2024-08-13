using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface IImageDal:IGeneric<Image>
    {
        public Task<EntityCommerce.Image> Upload(IFormFile formFile, int goodsId);
    }
}

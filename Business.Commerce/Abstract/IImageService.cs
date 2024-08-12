﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface IImageService
    {
        public Task<Image> UploadFile (Image image,IFormFile formFile);    
    }
}

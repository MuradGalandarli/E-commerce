using DataAccess.Commerce.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFImageRepository : Generic<Image>, IImageDal
    {

         private readonly ApplicationContext _context;
             
        public EFImageRepository(ApplicationContext context):base(context)
        {

            _context = context;

        }

        public async Task<EntityCommerce.Image> Upload(IFormFile imageFile,int goodsId)
        {
            if (imageFile.FileName.Length <= 0 || imageFile.FileName == null)
            {
                return null;
            }

            string uplaudFile = Path.Combine(Directory.GetCurrentDirectory(), "D:\\OnlayinTicaret");

            string fileName = Path.GetFileName(imageFile.FileName);

            string pathCombine = Path.Combine(uplaudFile, fileName);

            using (var fileStrim = new FileStream(pathCombine,FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStrim);
            }
            EntityCommerce.Image image = new()
            {
                OriginalPath = imageFile.FileName,
                SavedPath = pathCombine,
                UploadedAt = DateTime.UtcNow,
                GoodsId = goodsId
            
            };
            _context.Images.Add(image); 
            await _context.SaveChangesAsync();


           
            return image;    

        }

    }
}
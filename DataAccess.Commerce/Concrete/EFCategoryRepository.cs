using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFCategoryRepository: Generic<Category>,ICategoryDal
    {
        private readonly ApplicationContext _context;
        public EFCategoryRepository(ApplicationContext _context):base(_context)
        {
            this._context = _context;
        }

        public async Task<List<Category>> getallCategory()
        {

            var result = await _context.Categories.Where(x => x.CategoryStatus == true).ToListAsync();
           
            return result;
        }

      /*  public async Task Remove(int id)
        {
            *//*var result = await _context.Categories.FindAsync(id);
             result.CategoryStatus = false;
             *//*
            var result = await _context.Categories.FindAsync(id);
            if (result != null)
            {
                result.CategoryStatus = false;
                await _context.SaveChangesAsync();
            }*/

            public async Task RemoveCategory(int id)
            {
            var result = await _context.Categories.FindAsync(id);
                if (result != null)
                {    
                    result.CategoryStatus = false;
                   await  _context.SaveChangesAsync();
                }
            }
    }
}

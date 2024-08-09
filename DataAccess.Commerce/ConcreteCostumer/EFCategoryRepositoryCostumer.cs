using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFCategoryRepositoryCostumer : ICostumerCategoryDal
    {
        private readonly ApplicationContext _context;
        public EFCategoryRepositoryCostumer(ApplicationContext _context)
        {
            this._context = _context;
        }

     
public async Task<List<Category>> getAllList()
        {
            var result = await _context.Categories.Where(x=>x.CategoryStatus == true).ToListAsync();
            return result;
        }
  
    }
}

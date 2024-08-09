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
    public class EFGoodsRepositoryCostumer : ICostumerGoodsDal
    {
        private readonly ApplicationContext _context;
        public EFGoodsRepositoryCostumer(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Goods>> getAllList()
        {
            var result = await _context.Goodses.Where(x => x.Status == true).ToListAsync();
            return result;
        }

        public async Task<List<Goods>> searchForGoodsByCategory(string category)
        {
            var findCategoriId = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == category);
            if (findCategoriId != null)
            {
                var CatId = findCategoriId.CategoryId;
                var result = await _context.Goodses.Where(x => x.CategoryId == CatId).ToListAsync();
                return result;
            }
            return default;
        }


    }
}


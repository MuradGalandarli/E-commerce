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

        public  List<Goods> SearchGoods(Goods goods)
        {
            var query = _context.Goodses.AsQueryable();
            if(!string.IsNullOrEmpty(goods.GoodsName))
            {
               query = query.Where(x =>  x.GoodsName.Contains(goods.GoodsName) && x.Status == true);                
            }
             if(goods.Price > 0)
            {
               query = query.Where(x => x.Price <= goods.Price && x.Status == true);
            }
             if(goods.SellerId.HasValue && goods.SellerId > 0)
            {
               query = query.Where(x => x.SellerId == goods.SellerId && x.Status == true);
            }
            if (goods.CategoryId.HasValue && goods.CategoryId > 0)
            {
               query = query.Where(x => x.CategoryId <= goods.CategoryId && x.Status == true);
            }
            if (goods.Weight.HasValue && goods.Weight > 0)
            {
                query = query.Where(x => x.Weight <= goods.Weight && x.Status == true);
            }
            if (goods.Width.HasValue && goods.Width > 0)
            {
               query = query.Where(x => x.Width <= goods.Width && x.Status == true);
            }
            if (goods.Long.HasValue && goods.Long > 0)
            {
               query = query.Where(x => x.Long <= goods.Long && x.Status == true);
            }


            return  query.ToList();
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


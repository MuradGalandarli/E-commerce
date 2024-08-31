using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EFGoodsRepositoryCostumer> _logger;
        public EFGoodsRepositoryCostumer(ApplicationContext _context
            , ILogger<EFGoodsRepositoryCostumer> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        public async Task<List<Goods>> getAllList()
        {
            try
            {
                var result = await _context.Goodses.Where(x => x.Status == true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public  List<Goods> SearchGoods(Goods goods)
        {
            try
            {
                var query = _context.Goodses.AsQueryable();
                if (!string.IsNullOrEmpty(goods.GoodsName))
                {
                    query = query.Where(x => x.GoodsName.Contains(goods.GoodsName) && x.Status == true);
                }
                if (goods.Price > 0)
                {
                    query = query.Where(x => x.Price <= goods.Price && x.Status == true);
                }
                if (goods.SellerId.HasValue && goods.SellerId > 0)
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
                return query.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<List<Goods>> searchForGoodsByCategory(string category)
        {
            try
            {
                var findCategoriId = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryName == category);
                if (findCategoriId != null)
                {
                    var CatId = findCategoriId.CategoryId;
                    var result = await _context.Goodses.Where(x => x.CategoryId == CatId).ToListAsync();
                    return result;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());    
            }
            return default;
        }

        public async Task<string> GetShareLink(int goodsId)
        {
            try
            {
                var IsSuccess = await _context.Goodses.AnyAsync(x => x.GoodsId == goodsId && x.Status == true);
                if (IsSuccess)
                {
                    string shareLink = $"http://loclahost/api/Goods/getById/{goodsId}";
                    return shareLink;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;

        }
    }
}


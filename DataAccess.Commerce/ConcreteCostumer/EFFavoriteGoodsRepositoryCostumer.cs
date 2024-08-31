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
    public class EFFavoriteGoodsRepositoryCostumer : IFavoriteGoodsDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFFavoriteGoodsRepositoryCostumer> _logger;
        public EFFavoriteGoodsRepositoryCostumer(ApplicationContext _context
            , ILogger<EFFavoriteGoodsRepositoryCostumer> _logger)
        {
            this._context = _context;
            this._logger = _logger; 
        }
        public async Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoods favoriteGoods)
        {
            try
            {
                var goodsIsSuccess = await _context.Goodses.AnyAsync(x => x.Status == true && x.GoodsId == favoriteGoods.GoodesId);
                var userIsSuccess = await _context.Users.AnyAsync(x => x.Status == true && x.UserId == favoriteGoods.UserId);
                var checkFavoriteGoods = await _context.FavoriteGoods.
                    AnyAsync(x => x.UserId == favoriteGoods.UserId && x.GoodesId == favoriteGoods.GoodesId && x.Status == true);
                if (goodsIsSuccess && userIsSuccess && !checkFavoriteGoods)
                {
                    var result = await _context.FavoriteGoods.AddAsync(favoriteGoods);
                    await _context.SaveChangesAsync();
                    return favoriteGoods;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

     

        public async Task<List<Goods>> AllListFavoriteGoods(int userId)
        {
            try
            {
                var goodsId = await _context.FavoriteGoods.Where(x => x.Status == true && x.UserId == userId).Select(x => x.GoodesId).ToListAsync();
                var result = await _context.Goodses.Where(x => goodsId.Contains(x.GoodsId)).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());    
            }
            return null;
        }

        public async Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int favoriteGoodsId)
        {
            try
            {
                var result = await _context.FavoriteGoods.FirstOrDefaultAsync(x => x.FavoriteId == favoriteGoodsId);
                if (result != null)
                {
                    result.Status = false;
                    await _context.SaveChangesAsync();
                    return (result, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return (null, false);
        }


    }
}

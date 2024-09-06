using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumeFavoriteGoodsManager : ICostumerFavoriteGoodsService
    {
        private readonly IFavoriteGoodsDal _favoriteGoodsDal;
        private readonly ICostumerGenericRedis<Goods> _genericRedisGoods;
        public CostumeFavoriteGoodsManager(IFavoriteGoodsDal _favoriteGoodsDal
            ,ICostumerGenericRedis<Goods>_genericRedisGoods)
        {
            this._favoriteGoodsDal = _favoriteGoodsDal;
            this._genericRedisGoods = _genericRedisGoods;
        }

        public async Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoods favoriteGoods)
        {
            var result = await _favoriteGoodsDal.AddFavoriteGoods(favoriteGoods);
            await _genericRedisGoods.DeleteListRedis("FavoriteGoods");
           return result;
        }

        public async Task<List<Goods>> AllListFavoriteGoods(int userId)
        {
            var redisData = await _genericRedisGoods.GetListRedis("FavoriteGoods");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _favoriteGoodsDal.AllListFavoriteGoods(userId);
            await _genericRedisGoods.AddListRedis("FavoriteGoods", result );
            return result;
        }

        public async Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int id)
        {
            var result = await _favoriteGoodsDal.DeleteFavoriteGoods(id);
            await _genericRedisGoods.DeleteListRedis("FavoriteGoods");
            return result;
        }
    }
}

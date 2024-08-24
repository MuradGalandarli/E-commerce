using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
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
        public CostumeFavoriteGoodsManager(IFavoriteGoodsDal _favoriteGoodsDal)
        {
            this._favoriteGoodsDal = _favoriteGoodsDal;
        }
        public async Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoods favoriteGoods)
        {
           var result = await _favoriteGoodsDal.AddFavoriteGoods(favoriteGoods);
            return result;
        }

        public async Task<List<Goods>> AllListFavoriteGoods(int userId)
        {
            var result = await _favoriteGoodsDal.AllListFavoriteGoods(userId);
            return result;
        }

        public async Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int id)
        {
            var result = await _favoriteGoodsDal.DeleteFavoriteGoods(id);
            return result;
        }
    }
}

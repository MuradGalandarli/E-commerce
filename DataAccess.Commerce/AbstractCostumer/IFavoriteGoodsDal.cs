using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface IFavoriteGoodsDal
    {
        public Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoods favoriteGoods);
        public Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int favoriteGoodsId);
        public Task<List<Goods>> AllListFavoriteGoods(int userId);
      
    }
}

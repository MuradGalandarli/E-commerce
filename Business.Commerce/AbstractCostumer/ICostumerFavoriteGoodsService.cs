using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerFavoriteGoodsService
    {
        public Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoods favoriteGoods);
        public Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int id);
        public Task<List<Goods>> AllListFavoriteGoods(int userId);

    }
}

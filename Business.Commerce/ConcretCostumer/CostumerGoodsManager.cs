using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerGoodsManager:ICostumerGoodsService
    {
        private readonly ICostumerGoodsDal _costumerGoodsyDal;
        private readonly ICostumerGenericRedis<Goods> _costumerGenericRedis;
        public CostumerGoodsManager(ICostumerGoodsDal _costumerGoodsyDal
            , ICostumerGenericRedis<Goods> _costumerGenericRedis)
        {
            this._costumerGoodsyDal = _costumerGoodsyDal;
            this._costumerGenericRedis = _costumerGenericRedis;
        }

        public async Task<List<Goods>> GetAllList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("GetAllGoods");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _costumerGoodsyDal.getAllList();
            await _costumerGenericRedis.AddListRedis("GetAllGoods", result);
            return result;
        }

        public async Task<string> GetShareLink(int goodsId)
        {
            var result = await _costumerGoodsyDal.GetShareLink(goodsId);
            return result;
        }

        public async Task<List<Goods>> searchForGoodsByCategory(string category)
        {
            var result = await _costumerGoodsyDal.searchForGoodsByCategory(category);
            return result;
        }

        public List<Goods> SearchGoods(Goods goods)
        {
            var result =  _costumerGoodsyDal.SearchGoods(goods);
            return result;
        }
    }
}

using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerGoodsManager:ICostumerGoodsService
    {
        private readonly ICostumerGoodsDal _costumerGoodsyDal;
        public CostumerGoodsManager(ICostumerGoodsDal _costumerGoodsyDal)
        {
            this._costumerGoodsyDal = _costumerGoodsyDal;
        }

        public async Task<List<Goods>> GetAllList()
        {
            var result = await _costumerGoodsyDal.getAllList();
            return result;
        }

        public async Task<List<Goods>> searchForGoodsByCategory(string category)
        {
            var result = await _costumerGoodsyDal.searchForGoodsByCategory(category);
            return result;
        }
    }
}

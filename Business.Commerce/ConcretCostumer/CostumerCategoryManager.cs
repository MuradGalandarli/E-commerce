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
    public class CostumerCategoryManager : ICostumerCategorySevice
    {
        private readonly ICostumerCategoryDal _costumerCategoryDal;
        public CostumerCategoryManager(ICostumerCategoryDal _costumerCategoryDal)
        {
            this._costumerCategoryDal = _costumerCategoryDal;
        }
        public async Task<List<Category>> GetAllList()
        {
           var result = await _costumerCategoryDal.getAllList();
            return result;
        }

      
     /* public  Task<List<Goods>> searchForGoodsByCategory(string category)
        {
            var result = _costumerCategoryDal.searchForGoodsByCategory(category);
            return result;
        }*/
    }
}

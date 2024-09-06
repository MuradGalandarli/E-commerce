using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerCategoryManager : ICostumerCategorySevice
    {
        private readonly ICostumerCategoryDal _costumerCategoryDal;
        private readonly ICostumerGenericRedis<Category> _genericCostumerRedis;

        public CostumerCategoryManager(ICostumerCategoryDal _costumerCategoryDal
            ,ICostumerGenericRedis<Category> _genericCostumerRedis
            )
        {
            this._costumerCategoryDal = _costumerCategoryDal;
            this._genericCostumerRedis = _genericCostumerRedis;           
        }
        public async Task<List<Category>> GetAllList() 
        {
            
            var getRedis = await _genericCostumerRedis.GetListRedis("GetAllCategory");
            if (getRedis != null && getRedis.Count > 0)
            {
                return getRedis;
            }

            var data = await _costumerCategoryDal.getAllList();
            var json = JsonConvert.SerializeObject(data);
            await _genericCostumerRedis.AddListRedis("GetAllCategory", data);
            return data;

        }
    }
}

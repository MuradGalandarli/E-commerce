using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{

    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly ICostumerGenericRedis<Category> _costumerGenericRedis;
        public CategoryManager(ICategoryDal categoryDal
            ,ICostumerGenericRedis<Category> _costumerGenericRedis)
        {
            this._categoryDal = categoryDal;
            this._costumerGenericRedis = _costumerGenericRedis; 
        }

        public async Task<Category> Add(Category t)
        {
            
            t.CategoryStatus = true;
            await _categoryDal.Add(t);
            var json = JsonConvert.SerializeObject(t);
            await _costumerGenericRedis.AddListRedis("GetAllCategory", new List<Category> { t });
            return t;

        }

        public async Task<bool> Delete(int id)
         {
          var isTrue= await _categoryDal.RemoveCategory(id);
            await _costumerGenericRedis.DeleteListRedis("GetAllCategory");
            return isTrue;
        }

        

        public async Task<Category> GetbyId(int id)
        {           
           var result = await _categoryDal.GetById(id);
            if(result.CategoryStatus)
            {
                return result;
            }
            return null;
        }

        public async Task<List<Category>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("GetAllCategory");
            if (redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _categoryDal.getallCategory();
            await _costumerGenericRedis.AddListRedis("GetAllCategory", result);
            return result;
        }

        public async Task<Category> Update(Category t)
        {
            t.CategoryStatus = true;
            await _categoryDal.Update(t);
            await _costumerGenericRedis.DeleteKeyRedis("GetAllCategory");
            return t;
        }
    }
}

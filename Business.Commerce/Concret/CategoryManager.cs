using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
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
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        public async Task<Category> Add(Category t)
        {
            t.CategoryStatus = true;
          return await _categoryDal.Add(t);

        }

        public async Task<bool> Delete(int id)
         {
          var isTrue= await _categoryDal.RemoveCategory(id);
          
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
          var result = await _categoryDal.getallCategory();
         
            return result;
        }

        public async Task<Category> Update(Category t)
        {
            t.CategoryStatus = true; 
           return await _categoryDal.Update(t);
        }
    }
}

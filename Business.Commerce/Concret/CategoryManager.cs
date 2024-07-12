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
          return await _categoryDal.Add(t);

        }

        public async Task Delete(int id)
        {
           await _categoryDal.Delete(id);
        }

        public async Task<Category> GetbyId(int id)
        {
           return await _categoryDal.GetById(id);
        }

        public async Task<List<Category>> GetList()
        {
          var result = await _categoryDal.GetAll();
            return result;
        }

        public async Task<Category> Update(Category t)
        {
           return await _categoryDal.Update(t);
        }
    }
}

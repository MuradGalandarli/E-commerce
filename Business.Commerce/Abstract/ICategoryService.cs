using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public Task<List<Category>> getallCategory();
        public Task Delete(int id);
    }
}

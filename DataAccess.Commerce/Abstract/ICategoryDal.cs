using EntityCommerce;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface ICategoryDal:IGeneric<Category>
    {
        public Task RemoveCategory(int id);
        public Task <List<Category>> getallCategory();
    }
}

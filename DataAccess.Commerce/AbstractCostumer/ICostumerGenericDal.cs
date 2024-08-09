using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerGenericDal<T> where T :class
    {
        public Task<List<T>> getAllList();
    }
}

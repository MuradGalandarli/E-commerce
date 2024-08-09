using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerGoodsDal:ICostumerGenericDal<Goods>
    {
        public Task<List<Goods>> searchForGoodsByCategory(string category);

    }
}

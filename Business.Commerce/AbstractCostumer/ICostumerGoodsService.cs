using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerGoodsService:IGenericCostumer<Goods>
    {
        public Task<List<Goods>> searchForGoodsByCategory(string category);

    }
}

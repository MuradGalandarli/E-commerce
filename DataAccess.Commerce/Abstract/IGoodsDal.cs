using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
   public interface IGoodsDal:IGeneric<Goods>
    {
        public Task<bool> RemoveGoods(int id);
        public Task<List<Goods>> getallGoods();
    }
}

using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface ISellerDal:IGeneric<Seller>
    {
        public Task<bool> RemoveSeller(int id);
        public Task<List<Seller>> getallSeller();
    }
}

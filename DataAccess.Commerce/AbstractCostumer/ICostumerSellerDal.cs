using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerSellerDal
    {
        public Task<List<Seller>> GetAllListSeller();
        public Task<Seller> GetById(int id);
        public Task<List<Goods>> GetListSellerGoods(int sellerId);
    }
}

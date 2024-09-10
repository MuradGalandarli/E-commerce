using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFSellerRepositoryCostumer : ICostumerSellerDal
    {
        private readonly ApplicationContext _context;
        public EFSellerRepositoryCostumer(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> GetAllListSeller()
        {
            var data = await _context.Sellers.Where(x => x.Status == true).ToListAsync();
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Seller> GetById(int id)
        {
            var data = await _context.Sellers.FirstOrDefaultAsync(x => x.Status == true);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<List<Goods>> GetListSellerGoods(int sellerId)
        {
            var data = await _context.Goodses.Where(x=>x.Status == true && x.SellerId == sellerId).ToListAsync(); 
            if(data != null)
            {
                return data;
            }
            return null;
        }
    }
}
     
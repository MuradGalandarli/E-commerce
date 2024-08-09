using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFSellerRepository:Generic<Seller>,ISellerDal
    {
        private readonly ApplicationContext _context;
        public EFSellerRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Seller>> getallSeller()
        {
            var data = await _context.Sellers.Where(x => x.Status == true).ToListAsync();
            return data;
        }

        public async Task<bool> RemoveSeller(int id)
        {
            var data = await _context.Sellers.FindAsync(id);
            if(data != null)
            {
                data.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }



    }
}

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


    public class EfGoodsRepository:Generic<Goods>,IGoodsDal
    {
        private readonly ApplicationContext _context;
             
        public EfGoodsRepository(ApplicationContext context):base(context)
        {

            _context = context;

        }

        public async Task<List<Goods>> getallGoods()
        {
           var result = await _context.Goodses.Where(x => x.Status == true).ToListAsync();
            return result;
           
        }

        public async Task<bool> RemoveGoods(int id)
        {
           var data = await _context.Goodses.FindAsync(id);
            if (data != null)
            {
                data.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

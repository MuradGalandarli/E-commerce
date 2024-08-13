using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
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

        public Task<Goods> AddGoods(Goods goods, IFormFile imageFile)
        {
           
            throw new NotImplementedException();
        }

      

        public async Task<List<Goods>> getallGoods()
        {
           var result = await _context.Goodses.Where(x => x.Status == true).Include(i=>i.Image.Where(d=>d.IsDeleted == true)).ToListAsync();
            return result;
           
        }

        public async Task<bool> RemoveGoods(int id)
        {
           var data = await _context.Goodses.FindAsync(id);
           var result = await _context.Images.Where(x=>x.GoodsId == data.GoodsId).ToListAsync();
            foreach (var item in result)
            {
                item.IsDeleted = false;
            }
            
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

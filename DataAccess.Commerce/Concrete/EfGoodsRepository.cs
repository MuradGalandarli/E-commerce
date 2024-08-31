using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EfGoodsRepository> _logger;
             
        public EfGoodsRepository(ApplicationContext context
            , ILogger<EfGoodsRepository> _logger) :base(context,_logger)
        { 
            _context = context;
            this._logger = _logger;
        }

        public Task<Goods> AddGoods(Goods goods, IFormFile imageFile)
        {
           
            throw new NotImplementedException();
        }

      

        public async Task<List<Goods>> getallGoods()
        {
            try
            {
                var result = await _context.Goodses.Where(x => x.Status == true).Include(i => i.Image.Where(d => d.IsDeleted == true)).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<bool> RemoveGoods(int id)
        {
            try
            {
                var data = await _context.Goodses.FindAsync(id);
                var result = await _context.Images.Where(x => x.GoodsId == data.GoodsId).ToListAsync();
                var deleteGoodesFavorite = await _context.FavoriteGoods.Where(x => x.GoodesId == data.GoodsId).ToListAsync();

                foreach (var item in deleteGoodesFavorite)
                {
                    item.Status = false;
                    await _context.SaveChangesAsync();
                }

                foreach (var item in result)
                {
                    item.IsDeleted = false;
                    await _context.SaveChangesAsync();
                }

                if (data != null)
                {
                    data.Status = false;

                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return false;
        }
    }
}

using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EFSellerRepository> _logger;

        public EFSellerRepository(ApplicationContext context
            , ILogger<EFSellerRepository> _logger):base(context,_logger)
        {
            _context = context;
            this._logger = _logger;
        }

        public async Task<List<Seller>> getallSeller()
        {
            try
            {
                var data = await _context.Sellers.Where(x => x.Status == true).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<bool> RemoveSeller(int id)
        {
            try
            {
                var data = await _context.Sellers.FindAsync(id);
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

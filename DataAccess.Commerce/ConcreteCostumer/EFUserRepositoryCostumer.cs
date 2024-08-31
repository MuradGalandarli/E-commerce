using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFUserRepositoryCostumer : Generic<User>, ICostumerUserDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFUserRepositoryCostumer> _logger;
        public EFUserRepositoryCostumer(ApplicationContext context
            , ILogger<EFUserRepositoryCostumer> _logger
            ) : base(context,_logger)
        {
            _context = context;
            this._logger = _logger;
        }
        public async Task<List<User>> getallUser()
        {
            try
            {
                var data = await _context.Users.Where(x => x.Status == true).ToListAsync();
                return data;
            }catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<bool> RemoveUser(int id)
        {
            try
            {
                var data = await _context.Users.FindAsync(id);
                if (data != null)
                {
                    data.Status = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<List<User>> TheUsersPurchaseHistory(int userId)
        {
            try
            {
                var user = await _context.Users
              .Where(u => u.UserId == userId)
              .Include(u => u.Order)
                  .ThenInclude(o => o.Goods)
              .ToListAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());  
            }
            return null;

        }
    }
}

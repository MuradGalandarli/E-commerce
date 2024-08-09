using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
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
        public EFUserRepositoryCostumer(ApplicationContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<User>> getallUser()
        {
            var data = await _context.Users.Where(x => x.Status == true).ToListAsync();
            return data;
        }

        public async Task<bool> RemoveUser(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data != null)
            {
                data.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<User>> TheUsersPurchaseHistory(int userId)
        {
            //var datas = await _context.Users.ToListAsync();

            /*  var datas = await _context.Users
      .Include(x=>x.Order.))
  */
            var user = await _context.Users
          .Where(u => u.UserId == userId)
          .Include(u => u.Order)
              .ThenInclude(o => o.Goods)
          .ToListAsync();



            return user;

        }
    }
}

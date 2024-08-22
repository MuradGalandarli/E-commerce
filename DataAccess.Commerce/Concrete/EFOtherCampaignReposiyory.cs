using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFOtherCampaignReposiyory : IOtherCampaignDal
    {
        private readonly ApplicationContext _context;
        public EFOtherCampaignReposiyory(ApplicationContext _context)
        {
            this._context = _context;
        }

        public async Task<OtherCampaign> AddOtherCampaign(OtherCampaign otherCampaign)
        {
            var result = await _context.OtherCampaigns.AnyAsync(x=>x.IsDeleted == true && x.GoodsId == otherCampaign.GoodsId);
            if (!result)
            {
                if (otherCampaign.EndTime > DateTime.UtcNow)
                {
                    await _context.OtherCampaigns.AddAsync(otherCampaign);
                    await _context.SaveChangesAsync();
                    return otherCampaign;
                }
            }
            return null;
        }

        public async Task<List<OtherCampaign>> AllListOtherCampaign()
        {
            var result = await _context.OtherCampaigns.Where(x => x.IsDeleted == true).ToListAsync();
            return result;  
        }

        public async Task<(OtherCampaign, bool IsSuccess)> DeleteOtherCampaign(int id)
        {
            var result = await this.GetByIdOtherCampaign(id);
            if (result != null)
            {
                result.IsDeleted = false;
                await _context.SaveChangesAsync();
                return (result, true); 
            }
            return (result, false);
        }

        

        public async Task<OtherCampaign> GetByIdOtherCampaign(int id)
        {
            var result = await _context.OtherCampaigns.FirstOrDefaultAsync(x=>x.OtherCampaignId == id && x.IsDeleted == true);
            if(result != null)
            {
                return result;
            }
            return result;
        }

        public async Task<OtherCampaign> UpdateOtherCampaign(OtherCampaign otherCampaign)
        {
            _context.OtherCampaigns.Update(otherCampaign);
            await _context.SaveChangesAsync();
            return otherCampaign;
        }
    }
}

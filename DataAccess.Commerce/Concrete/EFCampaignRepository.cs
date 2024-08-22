using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace DataAccess.Commerce.Concrete
{
    public class EFCampaignRepository : ICampaignDal
    {
        private readonly ApplicationContext _context;
        public EFCampaignRepository(ApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<Campaign> AddCampaign(Campaign campaign)
        {
            if (campaign.EndDate > DateTime.UtcNow)
            {
                var checkGoods = await _context.Goodses.AnyAsync(x => x.SellerId == campaign.SellerId && x.GoodsId == campaign.GoodsId && x.Status == true);
                if (checkGoods)
                {
                    var checkCampaign = await _context.Campaigns.AnyAsync(x => x.SellerId == campaign.SellerId && x.GoodsId == campaign.GoodsId && x.IsDeleted == true);
                    if (!checkCampaign)
                    {
                        await _context.Campaigns.AddAsync(campaign);
                        await _context.SaveChangesAsync();
                        return campaign;
                    }
                }
            }
            return null;
        }

        public async Task<List<Campaign>> AllListCampaign()
        {
            var result = await _context.Campaigns.Where(x => x.IsDeleted == true).ToListAsync();
            return result;
        }

        public async Task<(Campaign, bool IsSuccess)> DeleteCampaign(int id)
        {
            var result = await this.GetByIdCampaign(id);
            if (result != null)
            {
                result.IsDeleted = false;
                await _context.SaveChangesAsync();
                return (result, true);
            }
            return (result, false);
        }

        public async Task<Campaign> GetByIdCampaign(int id)
        {
            var result = await _context.Campaigns.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Campaign> UpdateCampaign(Campaign campign)
        {
            _context.Campaigns.Update(campign);
            await _context.SaveChangesAsync();
            return campign;
        }
    }
}

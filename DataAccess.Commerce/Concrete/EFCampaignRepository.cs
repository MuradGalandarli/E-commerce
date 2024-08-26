using DataAccess.Commerce.Abstract;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailDal _emailDal;
        public EFCampaignRepository(ApplicationContext _context,
            UserManager<ApplicationUser> _userManager,
             IEmailDal _emailDal)
        {
            this._context = _context;
            this._userManager = _userManager;
            this._emailDal = _emailDal;
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
                        var goodsData = await _context.Goodses.Where(x => x.GoodsId == campaign.GoodsId).FirstOrDefaultAsync();

                        var userIdList = await _context.Orders.Where
                            (x => x.GoodsId == campaign.GoodsId && x.OrderStatus == Enums.OrderEnum.AddedToCart).
                            Select(x => x.UserId).ToListAsync();

                        var appUserId = await _context.Users.Where(x => userIdList.Contains(x.UserId)).
                            Select(x => new { x.ApplicationUserId ,x.UserName }).ToListAsync();

                        foreach (var item in appUserId)
                        {
                            var data = await _userManager.FindByIdAsync(item.ApplicationUserId);
                           await _emailDal.SendEmailAsync(data.Email, "Hello " + item.UserName, "The " + goodsData.GoodsName +" cost "+campaign.DiscountRate + " for 100");
                        }

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

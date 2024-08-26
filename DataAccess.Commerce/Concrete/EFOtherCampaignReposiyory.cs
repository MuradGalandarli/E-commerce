﻿using DataAccess.Commerce.Abstract;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFOtherCampaignReposiyory : IOtherCampaignDal
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser>_userManager;
        private readonly IEmailDal _emailDal;
        public EFOtherCampaignReposiyory(ApplicationContext _context,
            UserManager<ApplicationUser> _userManager,
            IEmailDal _emailDal)
        {
            this._context = _context;
            this._userManager = _userManager;  
            this._emailDal = _emailDal;
        }

        public async Task<OtherCampaign> AddOtherCampaign(OtherCampaign otherCampaign)
        {
            var checkOtherCampaigns = await _context.OtherCampaigns.AnyAsync(x=>x.IsDeleted == true && x.GoodsId == otherCampaign.GoodsId);
            if (!checkOtherCampaigns)
            {
                if (otherCampaign.EndTime > DateTime.UtcNow && otherCampaign.NumberOfReceipts > 0 && otherCampaign.GiftNumber > 0)
                {
                    await _context.OtherCampaigns.AddAsync(otherCampaign);
                    await _context.SaveChangesAsync();

                    var findUserId = await _context.Orders.Where(x=>x.OrderStatus == Enums.OrderEnum.AddedToCart && x.GoodsId == otherCampaign.GoodsId).
                        Select(x=>x.UserId).ToListAsync();
                     
                    var goodsName = await _context.Goodses.Where(x=>x.GoodsId == otherCampaign.GoodsId).Select(x=>x.GoodsName).FirstOrDefaultAsync();   

                    var appId = await _context.Users.Where(x => x.Status == true && x.Status && findUserId.Contains(x.UserId)).
                        Select(x => new { x.ApplicationUserId ,x.UserName}).ToListAsync();
                   foreach (var item in appId)
                    {
                       var result = await _userManager.FindByIdAsync(item.ApplicationUserId);
                                                                                                                                           
                        await _emailDal.SendEmailAsync 
                            (result.Email,"Hi " + item.UserName + ", don't waste the campaign ", "Buy "+ otherCampaign.NumberOfReceipts + " "+ goodsName + " and get "+ otherCampaign.GiftNumber + " free");
                    }

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

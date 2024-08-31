using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFCouponRepository : ICouponDal
    {
        private readonly ApplicationContext _context;
        public readonly ILogger<EFCouponRepository> _logger;

        public EFCouponRepository(ApplicationContext _context
            , ILogger<EFCouponRepository> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }
        public async Task<CouponGoods> AddCoupon(CouponGoods coupon)
        {
            try
            {
                var checkCoupon = await _context.CouponGoods.AnyAsync(x => x.CouponName != coupon.CouponName || x.IsDeleted == false);
                if (coupon.EndDate > DateTime.UtcNow && checkCoupon && coupon.Value > 0)
                {
                    await _context.AddAsync(coupon);
                    await _context.SaveChangesAsync();
                    return coupon;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;

        }

        public async Task<List<CouponGoods>> AllListCoupon()
        {
            try
            {
                var result = await _context.CouponGoods.Where(x => x.IsDeleted == true).ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<(CouponGoods, bool IsSuccess)> DeleteCoupon(int id)
        {
            try
            {
                var result = await this.GetByIdCoupon(id);
                if (result != null)
                {
                    result.IsDeleted = false;
                    await _context.SaveChangesAsync();
                    return (result, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return (null, false);
        }

        public async Task<CouponGoods> GetByIdCoupon(int id)
        {
            try
            {
                var result = await _context.CouponGoods.FirstOrDefaultAsync(x => x.CouponGoodsId == id);
                if (result != null)
                {
                    return result;
                }
            }catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<CouponGoods> UpdateCoupon(CouponGoods coupon)
        {
            try
            {
                _context.CouponGoods.Update(coupon);
                await _context.SaveChangesAsync();
                return coupon;
            }
            catch (Exception ex) 
            {
              _logger.LogError(ex.ToString());
            }
            return null;
        }
    }
}

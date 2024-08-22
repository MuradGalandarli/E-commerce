using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
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

        public EFCouponRepository(ApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<CouponGoods> AddCoupon(CouponGoods coupon)
        {

            var checkCoupon = await _context.CouponGoods.AnyAsync(x => x.CouponName != coupon.CouponName || x.IsDeleted == false);
            if (coupon.EndDate > DateTime.UtcNow && checkCoupon && coupon.Value > 0)
            {
                await _context.AddAsync(coupon);
                await _context.SaveChangesAsync();
                return coupon;
            }
            return null;

        }

        public async Task<List<CouponGoods>> AllListCoupon()
        {
            var result = await _context.CouponGoods.Where(x => x.IsDeleted == true).ToListAsync();
            return result;
        }

        public async Task<(CouponGoods, bool IsSuccess)> DeleteCoupon(int id)
        {
            var result = await this.GetByIdCoupon(id);
            if (result != null)
            {
                result.IsDeleted = false;
                await _context.SaveChangesAsync();
                return (result, true);
            }
            return (result, false);
        }

        public async Task<CouponGoods> GetByIdCoupon(int id)
        {
            var result = await _context.CouponGoods.FirstOrDefaultAsync(x => x.CouponGoodsId == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<CouponGoods> UpdateCoupon(CouponGoods coupon)
        {
            _context.CouponGoods.Update(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }
    }
}

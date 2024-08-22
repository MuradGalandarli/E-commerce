using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService _couponService)
        {
            this._couponService = _couponService;
        }

        [HttpPost("AddCoupon")]
        public async Task<IActionResult> addCoupon(CouponGoods couponGoods)
        {
            var result = await _couponService.Add(couponGoods);
           
            if(result != null)
            {
            return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetAllCoupon")]
        public async Task<IActionResult>getAllCoupon()
        {
            var result = await _couponService.GetList();
            if(result != null)
            {
            return Ok(result);
            }
            return BadRequest();    
        }
        [HttpPut("UpdateCoupon")]
        public async Task<IActionResult> UpdateCoupon(CouponGoods couponGoods)
        {
            var result = await _couponService.Update(couponGoods);
            return Ok(result);
        }
        [HttpGet("GetById {id}")]
        public async Task<IActionResult>GetById (int id)
        {
            var result = await _couponService.GetbyId(id);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpDelete("Delete {id}")]
        public async Task<IActionResult> Delete(int id)
        { 
        var result = await _couponService.DeleteCoupon(id);
           // return Ok(new {result.Item1, result.Item2 });
            return Ok(new { result.Item1, result.Item2 });
        }

    }
}

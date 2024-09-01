using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }
        [HttpPost("DeliveredGoods")]
        public async Task<IActionResult> DeliveredGoods(int userId, int goodsId) 
        {
            var result = await _orderService.DeliveredGoods(userId, goodsId);
            if(result.Item2)
            {
                return Ok(new{ Status = result.Item1, IsSuccess = result.Item2 });
            }
            return BadRequest(new { Status = result.Item1, IsSuccess = result.Item2 });
        }
        [HttpPost("ShippedGoods")]
        public async Task<IActionResult> ShippedGoods(int userId, int goodsId)
        {
            var result = await _orderService.ShippedGoods(userId, goodsId);
            if (result.Item2)
            {
                return Ok(new {Status = result.Item1,IsSuccess = result.Item2});
            }
            return BadRequest(new { Status = result.Item1, IsSuccess = result.Item2 });
        }
        [HttpPost("ReportGoods")]
        public async Task<IActionResult>CreateReport(Report report)
        {
            var result = await _orderService.ReportGoods(report);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}

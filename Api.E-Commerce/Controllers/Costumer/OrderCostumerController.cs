using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Commerce;
using System.Text.Json;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCostumerController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICostumerOrderService _costumerOrderService;

        public OrderCostumerController(
            IOrderService _orderService,
            ICostumerOrderService _costumerOrderService
            )
        {
            this._orderService = _orderService;
            this._costumerOrderService = _costumerOrderService;
        }

        [HttpGet("GetAllGoods")]
        public async Task<IActionResult> GetGoodsAllList()
        {
            var result = await _orderService.GetList();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            var result = await _costumerOrderService.AddOrder(order);
            if (result.IsSuccess)
            {
                return Ok(result.IsSuccess);
            }
            return BadRequest("The item has already been added to the cart.");
        }

        [HttpPut("updateOrder")]
        public async Task<IActionResult> UpdateOrder(Order order)
        {
            var result = await _orderService.Update(order);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getById {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _orderService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("DeleteOrder{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound();

        }
        [HttpPost("add-to-basket {id}")]
        public async Task<IActionResult> AddToBasket(int id, int number)
        {if (number > 0)
            {
                var result = await _costumerOrderService.addtoBasket(id, number);

                if (result != null)
                {
                    return Ok(result);
                }
            }
            return BadRequest();
        }
        [HttpGet("Ability-To-Track-Order-Status")]
        public async Task<IActionResult> abilityToTrackOrderStatus(int UserId,int Goods)
        {
            var result = await _costumerOrderService.abilityToTrackOrderStatus(Goods, UserId);
            if (result.Item1 != null && result.Item2 == true)
            {
                return Ok(result.Item1);
            }
           return NotFound(); 
        }








      /*  [HttpPost("BuyGoods")] 

        public async Task<IActionResult> Buy([FromBody]BuyGoodsRequest buyGoods)
        {
          var result = await _costumerOrderService.BuyGoods(buyGoods);
            if( result.IsSuccess && result.Item1 != null)
            {
                return Ok(result.Item1);
            }
            return BadRequest(result.IsSuccess);

        }*/


    }
}

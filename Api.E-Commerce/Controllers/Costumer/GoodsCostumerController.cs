using Business.Commerce.AbstractCostumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsCostumerController : ControllerBase
    {
        private readonly ICostumerGoodsService _costumerGoodsService;
        public GoodsCostumerController(ICostumerGoodsService _costumerGoodsService)
        {
            this._costumerGoodsService = _costumerGoodsService;
        }
        [HttpGet("GetAllGoods")]
        public async Task<IActionResult> GetAllListCostumer()
         {
           var result = await _costumerGoodsService.GetAllList();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("searchForGoodsByCategory")]
        public async Task<IActionResult> GetCategory(string category)
        {
            var result = await _costumerGoodsService .searchForGoodsByCategory(category);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}

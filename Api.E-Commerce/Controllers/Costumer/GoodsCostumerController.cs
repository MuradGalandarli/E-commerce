using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;

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
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                string jsonString = JsonSerializer.Serialize(result, options);
                return Ok(jsonString);
            }
            return BadRequest();
        }

        [HttpPost ("SearchGoods")]
        public IActionResult SearchGodds([FromBody]Goods goods)
        {
            var result =  _costumerGoodsService.SearchGoods(goods);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();    
        }
        [HttpPost("GetShareLink")]
        public async Task<IActionResult> GetShareLink(int goodsId)
        { 
          var result = await _costumerGoodsService.GetShareLink(goodsId);
            if(result != null)
            {
                return Ok(result);
            }
            return NotFound();

        }
         





    }
}

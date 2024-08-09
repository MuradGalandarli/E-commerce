using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {

        private readonly IGoodsService _goodsService;

        public GoodsController(IGoodsService _goodsService)
        {
            this._goodsService = _goodsService;
        }

        [HttpGet("GetAllGoods")]
        public async Task<IActionResult> GetGoodsAllList()
        {
            var result = await _goodsService.GetList();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpPost("addGoods")]
        public async Task<IActionResult> AddGoods(Goods goods)
        {
            var result = await _goodsService.Add(goods);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("updateGoods")]
        public async Task<IActionResult> UpdateGoods(Goods goods)
        {
            var result = await _goodsService.Update(goods);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _goodsService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("DeleteGoods{id}")]
        public async Task<IActionResult> Delete(int id)
        {
          var result = await _goodsService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

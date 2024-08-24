using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

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

                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve, 
                    MaxDepth = 64, 
                    WriteIndented = true 
                };

                var jsonString = JsonSerializer.Serialize(result, options);


                return Ok(jsonString);
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

        [HttpDelete("DeleteGoodsImageFavorite{id}")]
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

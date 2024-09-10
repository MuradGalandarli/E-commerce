using Business.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteGoodsController : ControllerBase
    {
        private readonly ICostumerFavoriteGoodsService _favouriteGoodsService;
        public FavoriteGoodsController(ICostumerFavoriteGoodsService _favouriteGoodsService)
        {
            this._favouriteGoodsService = _favouriteGoodsService;
        }

        [HttpGet("AllListFavoriteGoods{userId}")]
        public async Task<IActionResult> AllListFavoriteGoods(int userId)
        {
            var result = await _favouriteGoodsService.AllListFavoriteGoods(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("AddFavoriteGoods")]
        public async Task<IActionResult> AddFavoriteGoods([FromBody] FavoriteGoodsDto favoriteGoods)
        {
             var result = await _favouriteGoodsService.AddFavoriteGoods(favoriteGoods);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteFavoriteGoods{favoriteGoodsId}")]
        public async Task<IActionResult>DeleteFavoriteGoods(int favoriteGoodsId) 
        {
           var result = await _favouriteGoodsService.DeleteFavoriteGoods(favoriteGoodsId);
            if(result.IsSuccess == true)
            {
                return Ok(new { result.Item1,result.IsSuccess });
            }
            return BadRequest(new { result.Item1, result.IsSuccess });
        }





}
}

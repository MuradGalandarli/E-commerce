using Business.Commerce.AbstractCostumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerCostumerController : ControllerBase
    {
        private readonly ICostumerSellerService _costumerSellerService;
        public SellerCostumerController(ICostumerSellerService _costumerSellerService)
        {
            this._costumerSellerService = _costumerSellerService;
        }

        [HttpGet("GetListSellerGoods{id}")]
        public async Task<IActionResult> GetListSellerGoods(int id)
        {
            var result = await _costumerSellerService.GetListSellerGoods(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetAllListSeller")]
        public async Task<IActionResult> GetAllList()
        {
            var result = await _costumerSellerService.GetAllList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _costumerSellerService.GetById(id);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }





    }
}

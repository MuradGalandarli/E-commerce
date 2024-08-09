using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService _sellerService)
        {
            this._sellerService = _sellerService;
        }

        [HttpGet("GetAllSeller")]
        public async Task<IActionResult> GetSellerAllList()
        {
            var result = await _sellerService.GetList();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpPost("addSeller")]
        public async Task<IActionResult> AddSeller(Seller seller)
        {
            var result = await _sellerService.Add(seller);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("updateSeller")]
        public async Task<IActionResult> UpdateSeller(Seller seller)
        {
            var result = await _sellerService.Update(seller);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getById{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sellerService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("DeleteSeller{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var isTrue = await _sellerService.Delete(id);
            if (isTrue)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

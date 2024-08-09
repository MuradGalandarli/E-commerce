using Business.Commerce.AbstractCostumer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryCostumerController : ControllerBase
    {
        private readonly ICostumerCategorySevice _categorySevice;
        public CategoryCostumerController(ICostumerCategorySevice _categorySevice)
        {
            this._categorySevice = _categorySevice;
        }

        [HttpGet("GetAllCategory")]
        public async Task<IActionResult>GetAllCategory()
        {
            var result = await _categorySevice.GetAllList();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
       

    }
}

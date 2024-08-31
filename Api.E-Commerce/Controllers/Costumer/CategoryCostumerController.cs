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
        ILogger<CategoryCostumerController> logger;
        public CategoryCostumerController(ICostumerCategorySevice _categorySevice,
            ILogger<CategoryCostumerController> _logger)
        {
            this._categorySevice = _categorySevice;
            logger = _logger;
           
        }


        [HttpGet("GetAllCategory")]
        public async Task<IActionResult>GetAllCategory()
        {
            var result = await _categorySevice.GetAllList();
            if(result != null)
            {
                logger.LogInformation("Salam");
                return Ok(result);
            }
            return BadRequest();
        }
       

    }
}

using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        public CampaignController(ICampaignService _campaignService)
        {
            this._campaignService = _campaignService;
        }


        [HttpGet("GetbyId")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _campaignService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AddCampaign")]
        public async Task<IActionResult> AddCampaign(Campaign comparer)
        {
            var result = await _campaignService.Add(comparer);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("campaignUpdate")]
        public async Task<IActionResult> CampaignUpdate(Campaign comparer)
        {
            var result = await _campaignService.Update(comparer);
            return Ok(result);

        }
        [HttpGet("GetAllList")]
        public async Task<IActionResult> AllList()
        {
            var result = await _campaignService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("Delete{id}")]
        public async Task<IActionResult>Remove(int id)
        {
            var result = await _campaignService.DeleteCampaign(id);
            return Ok(new { result.Item1,IsSuccess = result.Item2 });  
        }




    }
}

using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtherCampaignController : ControllerBase
    {
        private readonly IOtherCampaignService _therCampaignService;
        public OtherCampaignController(IOtherCampaignService _therCampaignService)
        {
            this._therCampaignService = _therCampaignService;
        }
        [HttpGet("GetbyIdOtherCampaign")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _therCampaignService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AddOtherCampaignOther")]
        public async Task<IActionResult> AddOtherCampaign(OtherCampaign otherComparer)
        {
            var result = await _therCampaignService.Add(otherComparer);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPut("OtherCampaignUpdate")]
        public async Task<IActionResult> CampaignUpdate(OtherCampaign otherComparer)
        {
            var result = await _therCampaignService.Update(otherComparer);
            return Ok(result);

        }
        [HttpGet("GetAllListOtherCampaign")]
        public async Task<IActionResult> AllList()
        {
            var result = await _therCampaignService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("DeleteOtherCampaign{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _therCampaignService.RemoveOtherCampaign(id);
            return Ok(new { result.Item1, IsSuccess = result.Item2 });
        }


    }
}

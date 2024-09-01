using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerCostumerController : ControllerBase
    {
        private readonly ICostumerAnswerService _answerService;

        public AnswerCostumerController(ICostumerAnswerService _answerService)
        {
            this._answerService = _answerService;
        }

        [HttpGet("GetListAnswer")]
        public async Task<IActionResult> GetList()
        {
            var result = await _answerService.GetList();
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetByIdAnswer")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _answerService.GetbyId(id);  
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("AnswerAdd")]
        public async Task<IActionResult> AnswerAdd([FromBody]Answer answer)
        {
            var result = await _answerService.Add(answer);
            if(result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("DeleteAnswer{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {

            var result = await _answerService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPut("UpdateAnswer")]
        public async Task<IActionResult> UpdateAnswer(Answer answer)
        {
            var result = await _answerService.Update(answer);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        }
    }

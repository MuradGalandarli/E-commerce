using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionCostumerController : ControllerBase
    {
        private readonly ICostumerQuestionService _questionService;
        public QuestionCostumerController(ICostumerQuestionService _questionService)
        {
            this._questionService = _questionService;
        }

        [HttpGet("GetListQuestion")]
        public async Task<IActionResult> GetList()
        {
            var result = await _questionService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("GetByIdQuestion")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _questionService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("QuestionAdd")]
        public async Task<IActionResult> QuestionAdd([FromBody] Question question)
        {
            var result = await _questionService.Add(question);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("DeleteQuestion{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {

            var result = await _questionService.Delete(id);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPut("UpdateQestion")]
        public async Task<IActionResult> UpdateQuestion(Question question)
        {
            var result = await _questionService.Update(question);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("QuestionLikeOrDisLike")]
        public async Task<IActionResult> QuestionLikeOrDisLike(QuestionLike questionLike)
        {
            var result = await _questionService.QuestionLikeOrDisLike(questionLike);
            return Ok(result);

        }
       






    }
}

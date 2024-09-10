using Business.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentCostumerController : ControllerBase
    {
        private readonly ICostumerCommentService _costumerCommentService;
        public CommentCostumerController(ICostumerCommentService _costumerCommentService)
        {
            this._costumerCommentService = _costumerCommentService;
        }

        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment([FromBody] CommentDto comment)
        {
            var result = await _costumerCommentService.CreateComment(comment);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetByIdListCommnt{goodsId}")]
        public async Task<IActionResult> GetList(int goodsId)
        {
            var result = await _costumerCommentService.GetByIdListCommnt(goodsId);
            if (result != null && result.Count > 0)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("LikeOrDisLike")]
        public async Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike)
        {
            var result = await _costumerCommentService.LikeOrDisLike(userId, commentId, statusLike);
            return result;
        }
        [HttpGet("GetAllComment")]
        public async Task<IActionResult> GetAllComment()
        {
            var result = await _costumerCommentService.GetAllComment();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpDelete("DeleteComment{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var IsSuccess = await _costumerCommentService.DeleteComment(id);
            if (IsSuccess)
            {
                return Ok(IsSuccess);
            }
            return BadRequest();
        }
        [HttpPut("UpdateComment")]
        public async Task<IActionResult> UpdateComment([FromBody]CommentDto comment)
        {
            var result = await _costumerCommentService.UpdateComment(comment);
            return Ok(result);
        }

    }
}

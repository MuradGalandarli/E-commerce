using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerCommentService
    {
        public Task<CommentDto> CreateComment(CommentDto comment);
        public Task<List<CommentDto>> GetByIdListCommnt(int goodsId);
        public Task<List<CommentDto>> GetAllComment();
        public Task<bool> DeleteComment(int commentId);
        public Task<CommentDto> UpdateComment(CommentDto comment);
        public Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike);
    }
}

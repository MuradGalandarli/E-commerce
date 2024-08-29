using EntityCommerce.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCommerce
{
    public class AnswerLike
    {
        public int AnswerLikeId { get; set; }
        public int UserId { get; set; }
        public Enums.likeEnum? LikeStatus { get; set; } = Enums.likeEnum.Neutral;
        [NotMapped]
        public Enums.likeEnum? LikeOrDisLike { get; set; }
        public int AnswerId { get; set; }
        public Answer? Answer { get; set; }
    }
}

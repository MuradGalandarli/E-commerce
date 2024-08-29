using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class QuestionLike
    {
        public int QuestionLikeId { get; set; }
        public int UserId { get; set; }
        public Enums.likeEnum? LikeStatus { get; set; } = Enums.likeEnum.Neutral;
        [NotMapped]
        public Enums.likeEnum? LikeOrDisLike { get; set; }

        public int QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}

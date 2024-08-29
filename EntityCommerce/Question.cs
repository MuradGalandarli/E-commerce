using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public DateTime QuestionDate{ get; set; } = DateTime.UtcNow;
        public int Like { get; set; }
        public int DisLike { get; set; }
        public bool Status { get; set; } = true;
        public int UserId { get; set; }
        public User? User { get; set; }  
        public List<Answer>? Answers { get; set; }
        public List<QuestionLike>? QuestionsLikes { get; set; }



    }
}

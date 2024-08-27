using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string? AnswerText { get; set; }
        public DateTime AnswerDate { get; set; } = DateTime.UtcNow;
        public bool Status { get; set; } = true;
        public int QuestionId { get; set; } 
        public Question? Question { get; set; } 
        public int UserId { get; set; } 
        public User? User { get; set; } 

    }
}

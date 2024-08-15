using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }      
      
        public int? UserId { get; set; } 
        public User? User { get; set; }
        public int? CommentId { get; set; }  
        public Comment? Comment { get; set; }
        public int StatusLike { get; set; } = 2;
    }
}

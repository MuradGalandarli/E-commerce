using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? GoodsId { get; set; }
        public Goods? Goods { get; set; }
        public List<Like>? Like { get; set; }

    }
}

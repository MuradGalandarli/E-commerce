using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.EntityDto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string? CommentText { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public int DisLikeCount { get; set; }

    //    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    //    public bool IsDeleted { get; set; } = true;
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? GoodsId { get; set; }
        public Goods? Goods { get; set; }
        public List<Like>? Like { get; set; }
    }
}

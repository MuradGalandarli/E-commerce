using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class FavoriteGoods
    {
        [Key]
        public int FavoriteId { get; set; } 
        public int GoodesId { get; set; } 
        public Goods? Goods { get; set; }    
        public int UserId { get; set; } 
        public User? User { get; set; }
        public bool Status { get; set; } = true;  

    }
}

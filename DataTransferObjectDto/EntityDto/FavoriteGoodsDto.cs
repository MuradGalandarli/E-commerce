using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.EntityDto
{
    public class FavoriteGoodsDto
    {
     //   public int FavoriteId { get; set; }
       public int GoodesId { get; set; }
    //    public Goods? Goods { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

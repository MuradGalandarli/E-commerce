using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Order
    {
        public int OrderId { get; set; }
        public bool Basket { get; set; }
        public bool Buy { get; set; }
        public bool Status { get; set; }

        public int GoodsId { get; set; } 
        public Goods Goods { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static EntityCommerce.Enum.Enums;

namespace EntityCommerce
{
    public class Order
    {
        public int OrderId { get; set; }
     
        public int GoodsId { get; set; }
        public byte NumberOfGoods { get; set; }

        public OrderEnum OrderStatus { get; set; } = OrderEnum.NotAddedToCart;
        [JsonIgnore]
        public Goods? Goods { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        /*  public string UserId { get; set; }

          public ApplicationUser? User { get; set; }*/

    }
}

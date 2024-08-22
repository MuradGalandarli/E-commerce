using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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
        public string? CouponName { get; set; }
        public int? CouponId { get; set; }
        public int? OtherCampaignId { get; set; }
        public decimal? CouponDiscountedPrice { get; set; }
        public int? CampaignId { get; set; }
        public OrderEnum OrderStatus { get; set; } = OrderEnum.NotAddedToCart;
        [JsonIgnore]
        public Goods? Goods { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }


    }
}

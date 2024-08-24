using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Goods
    {
        [Key]
        public int GoodsId { get; set; }
        public string? GoodsName { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public string? Color { get; set; }
        public float? Weight { get; set; }
        public float? Width { get; set; }
        public float? Long { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        public List<Order>? Order { get; set; }

        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

       public List<Image>? Image { get; set; }

        public List<Comment>? Comments { get; set; }

        public List<Campaign>? Campaigns { get; set; }

        public List<CouponGoods>? CouponGoods { get; set; }

        public List<OtherCampaign>? OtherCampaign { get; set; }
        public List<FavoriteGoods>? FavoriteGoods { get; set; }  
        
        
    }
}

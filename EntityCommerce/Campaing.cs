using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Campaign
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public decimal DiscountRate { get; set; } //endirim
        public bool IsDeleted { get; set; }
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }
        public int GoodsId { get; set; }
        public Goods? Goods { get; set; }
    }

}

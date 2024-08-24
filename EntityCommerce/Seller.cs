using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Seller
    {
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public string? SellerSureName { get; set; }
        public string? SellerGmail { get; set; }
        public string? Password { get; set; }
        public string? Rol { get; set; }
        public bool Status { get; set; }
        public List<Goods>? Goods { get; set; }
        public string ApplicationUserId { get; set; }
        ApplicationUser ApplicationUser { get; set; }
        public List<Campaign>? Campaigns { get; set; }
    }
}

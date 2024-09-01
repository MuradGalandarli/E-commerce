using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Report
    {
        public int ReportId { get; set; }
        public string? ReportName { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public Decimal? TotalPrice { get; set; } // pullun totali
        public int RemainingInStock { get; set; } // Stoqda qalan mallarin sayi
        public int NumberSold { get; set; } // satilan mallarin sayi
        public bool Status { get; set; } = true;
        public int? GoodsID { get; set; }
        public int SellerId { get; set; }
        public Seller? Seller { get; set;}



    }
}

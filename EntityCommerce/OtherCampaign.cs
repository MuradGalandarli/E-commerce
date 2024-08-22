using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class OtherCampaign
    {
        [Key]
        public int OtherCampaignId { get; set; } 
        public int GiftNumber { get; set; } // buy count
        public bool IsDeleted { get; set; }
        public int NumberOfReceipts { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow; 
        public DateTime EndTime { get; set; } 
        public int GoodsId { get; set; }    
        public Goods? Goods { get; set; }


    }
}

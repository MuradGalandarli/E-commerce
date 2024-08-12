using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? OriginalPath { get; set; }
        public string? SavedPath { get; set; }
        public DateTime UploadedAt { get; set; }     
        public int? GoodsId { get; set; }    
        public Goods? Goods { get; set; }

    }
}

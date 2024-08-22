using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class CouponGoods
    {
        [Key]
        public int CouponGoodsId { get; set; }

        // KPI'nın adı (örneğin, "Gelir Artışı").
        public string CouponName { get; set; }

        // KPI'nın neyi ölçtüğünü açıklayan kısa bir açıklama.
        public string? Description { get; set; }

        // KPI için hedeflenen değer.
        public decimal? Value { get; set; }

        public bool IsDeleted { get; set; }
        // KPI'nın ölçüldüğü dönemin başlangıç tarihi.
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

        // KPI'nın ölçüldüğü dönemin bitiş tarihi.
        public DateTime EndDate { get; set; }


        public List<Goods>? Goods { get; set; }


    }

}
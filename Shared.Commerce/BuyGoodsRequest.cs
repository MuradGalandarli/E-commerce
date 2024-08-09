using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commerce
{
    public class BuyGoodsRequest
    {
        public int UserId { get; set; }
        public int GoodsId { get; set; }
        public int Number { get; set; }
    }
}

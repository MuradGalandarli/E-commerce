using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commerce
{
    public class CreatePaymentIntentRequest
    {
       
        public int GoodsId { get; set; }
        public int UserId { get; set; }
        public string? Currency { get; set; }
    //    public string? CustomerId { get; set; }
       // public string? PaymentMethodId { get; set; }
    }
}

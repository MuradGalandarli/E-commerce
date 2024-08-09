using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Payment
    {
        public int Id { get; set; }    
        public int UserID { get; set; }
        public string PaymentID { get; set; }
        public string CustomerID { get; set; }
    }
}

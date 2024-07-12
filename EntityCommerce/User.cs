using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSureName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public bool Status { get; set; }

        List<Order>Order { get; set; }
    }
}

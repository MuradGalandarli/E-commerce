


using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class ApplicationUser:IdentityUser
    {
        public string? PasswordResetToken { get; set; }
        public DateTime? PasswordResetTokenExpiry { get; set; }
      /*  public ICollection<Order> Orders { get; set; }*/

        public User usre { get; set; }
        public Seller Seller { get; set; }


    }
}

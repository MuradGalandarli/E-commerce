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
        public List<Order>? Order { get; set; }
        public List<Comment>Comments { get; set; }
        public string ApplicationUserId { get; set; }
        ApplicationUser ApplicationUser { get; set; }
        public List<Like>? Like { get; set; }
    }
}

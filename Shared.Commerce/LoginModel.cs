using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commerce
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
        [Required (ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Rol is required")]
        public string Rol { get; set; }
    }
}

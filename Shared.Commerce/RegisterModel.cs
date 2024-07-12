using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commerce
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="User name is required")]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Passwor is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string? Role { get; set; }

    }
}

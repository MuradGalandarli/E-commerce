using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Commerce
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; } // Şifresi sıfırlanacak kullanıcının e-posta adresi

        public string Token { get; set; } // Şifre sıfırlama işlemi için kullanılacak token

        public string Password { get; set; } // Yeni şifre

        public string ConfirmPassword { get; set; }
    }
}

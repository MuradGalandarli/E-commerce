using EntityCommerce;
using Microsoft.AspNetCore.Mvc;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface IAuthService
    {
        Task <Object> Login (LoginModel model);

        Task<(bool isSuccess,List<string>Message)> Register(RegisterModel model);

       Task<(bool isSuccess,List<string> Message)> ForgotPassword(ForgotPasswordRequest forgot);

        Task<(bool isSuccess,List<string> errors)> ResetPassword(ResetPasswordRequest reset);

        
    }

    
}

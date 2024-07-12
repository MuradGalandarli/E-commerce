using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Business.Commerce.Concret
{
    public class AuthManager :  IAuthService
    {

        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IUrlHelper _urlHelper;


        public AuthManager(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor,
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IConfiguration _configuration,
            IEmailService _emailService,
            IUrlHelper _urlHelper
            
            )
        {
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._configuration = _configuration;
            this._emailService = _emailService;
            this._urlHelper = _urlHelper;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
  

        }

    

        public async Task<(bool isSuccess,List<string>Message)> ForgotPassword(ForgotPasswordRequest forgot)
        {
            var Message = new List<string>();

            if (string.IsNullOrEmpty(forgot.Email))
            {
                Message.Add("Email cannot be null");
                return (false, Message);
            }

            var user = await _userManager.FindByEmailAsync(forgot.Email);

            if (user == null)
            {
                Message.Add("Internal server error: Auth service is not initialized");
                return (false,Message);
            }


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // Tokenı veritabanında saklayın
            user.PasswordResetToken = token;
            user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1); 
            await _userManager.UpdateAsync(user);
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var resetLink = urlHelper.Action("ResetPassword", "Auth", new { token });

            

            // E-posta gönderme kodu burada olacak
            await _emailService.SendEmailAsync(forgot.Email, "Reset Password", $"Please reset your password by clicking <a href='{resetLink}'>here</a>.");
            Message.Add("Link sent to email");
            return (true,Message);
        }

        public async Task<Object> Login(LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.UserName);
            var checkRol = await _userManager.GetRolesAsync(user);

            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password)
                && checkRol.Contains(model.Rol))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Role,model.Rol),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);

                return new
                {
                    PasswordResetToken = new JwtSecurityTokenHandler().WriteToken(token),
                    PasswordResetTokenExpiry = token.ValidTo.ToString()
                };
                
            }
            
            return null;

        }

        public async Task<(bool isSuccess,List<string> Message)> Register(RegisterModel model)
        {
            var message = new List<string>();
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                message.Add("User already exists!");
                return (false, message);
            }
            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                message.Add("User creation failed! Please check user details and try again.");
                return (false, message);
            }
            // Rolün mevcut olup olmadığını kontrol edin ve yoksa oluşturun
            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            // Kullanıcıya rolü ekleyin
            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }
            message.Add("User created ");
            return (true,message);
            
        }

        public async Task<(bool isSuccess, List<string> errors)> ResetPassword(ResetPasswordRequest reset)
        {
            var Message = new List<string>();
            if (string.IsNullOrEmpty(reset.Email))
            {
                Message.Add("Email can not empty or null");
                return (false,Message);
            }

            var user = await _userManager.FindByEmailAsync(reset.Email);

         
            if (user == null && reset.Password == reset.ConfirmPassword)
            {
                Message.Add("Invalid email address.");
                return (false, Message);
            }

            var result = await _userManager.ResetPasswordAsync(user, reset.Token, reset.Password);
            if (result.Succeeded)
            {
                Message.Add("Password has been reset successfully.");
                return (true, Message);
            }

            foreach (var err in result.Errors)
            {
                Message.Add(err.Description.ToString());
            }

            return (false,Message);

           
        }

            private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

      
    }
}

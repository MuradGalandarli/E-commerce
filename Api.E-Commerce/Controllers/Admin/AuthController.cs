using Business.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.IsisMtt.X509;
using Shared.Commerce;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.E_Commerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly private UserManager<ApplicationUser> _userManager;
        readonly private RoleManager<IdentityRole> _roleManager;
        readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IAuthService _authService;


        public AuthController(
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IConfiguration _configuration,
            IEmailService _emaiService,
            IAuthService _authService
            )
        {
            // _appUserManager = appUserManager;
            this._userManager = _userManager;
            this._roleManager = _roleManager;
            this._configuration = _configuration;
            this._emailService = _emaiService;
            this._authService = _authService;   

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {

            /*var user = await _userManager.FindByNameAsync(loginModel.UserName);
            var checkRol = await _userManager.GetRolesAsync(user);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password)
                && checkRol.Contains(loginModel.Rol))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Role,loginModel.Rol),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };
                 
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo.ToString()
                });
            }*/
            var result = await _authService.Login(loginModel);

            if ( result != null)
            {
                return Ok(result.ToString());
            }

            return Unauthorized();
        }



        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            /* var userExists = await _userManager.FindByNameAsync(model.Username);
             if (userExists != null)
                 return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

             ApplicationUser user = new()
             {
                 Email = model.Email,
                 SecurityStamp = Guid.NewGuid().ToString(),
                 UserName = model.Username
             };
             var result = await _userManager.CreateAsync(user, model.Password);
             if (!result.Succeeded)
                 return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

             // Rolün mevcut olup olmadığını kontrol edin ve yoksa oluşturun
             if (!await _roleManager.RoleExistsAsync(model.Role))
             {
                 await _roleManager.CreateAsync(new IdentityRole(model.Role));
             }

             // Kullanıcıya rolü ekleyin
             if (await _roleManager.RoleExistsAsync(model.Role))
             {
                 await _userManager.AddToRoleAsync(user, model.Role);
             }*/

            
            var result = await _authService.Register(model);

            if (result.isSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }



       /* private JwtSecurityToken GetToken(List<Claim> authClaims)
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
        }*/

     


        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {

            var result = await _authService.ForgotPassword(model);

            if(result.isSuccess)
            {
               return Ok(result.Message);
            }
            
            return BadRequest(result.Message);



            /*   if (!ModelState.IsValid)
               {
                   return BadRequest(ModelState);
               }

               var user = await _userManager.FindByEmailAsync(model.Email);


               if (user == null)
               {
                   return BadRequest("Invalid email address.");
               }

             //  var token = Guid.NewGuid().ToString();
               var token = await _userManager.GeneratePasswordResetTokenAsync(user);
               // Tokenı veritabanında saklayın
               user.PasswordResetToken = token;
               user.PasswordResetTokenExpiry = DateTime.UtcNow.AddHours(1); // Tokenın geçerlilik süresi 1 saat
               await _userManager.UpdateAsync(user);





               // var token1 = await _userManager.GeneratePasswordResetTokenAsync(user);

               var resetLink = Url.Action("ResetPassword", "Auth", new { token });

               // E-posta gönderme kodu burada olacak
               await _emailService.SendEmailAsync(model.Email, "Reset Password", $"Please reset your password by clicking <a href='{resetLink}'>here</a>.");
   */

        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest model)
        {
            
            var result =await _authService.ResetPassword(model);
            if(result.isSuccess)
            {
                return Ok(result.errors);
            }
            return BadRequest(result);

        }
          /*  if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            //|| !await _userManager.IsEmailConfirmedAsync(user)
            if (user == null && model.Password == model.ConfirmPassword)
            {
                return BadRequest("Invalid email address.");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return Ok("Password has been reset successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }*/

    }

}
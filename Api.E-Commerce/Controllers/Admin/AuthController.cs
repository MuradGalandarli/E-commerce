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
            
            
            var result = await _authService.Register(model);

            if (result.isSuccess)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest model)
        {

            var result = await _authService.ForgotPassword(model);

            if(result.isSuccess)
            {
               return Ok(result.Message);
            }
            
            return BadRequest(result.Message);



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
         
    }

}
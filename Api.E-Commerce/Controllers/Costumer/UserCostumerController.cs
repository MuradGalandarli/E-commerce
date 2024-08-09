using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCostumerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICostumerUserService _costumerUserService;
            
        public UserCostumerController(
            IUserService _userService,
            ICostumerUserService _costumerUserService)
        {

            this._userService = _userService;
            this._costumerUserService = _costumerUserService;
        }


        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetCategoryAllList()
        {


            var result = await _userService.GetList();

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();

        }
        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = await _userService.Add(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(User user)
        {
            var result = await _userService.Update(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("getById {id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetbyId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("DeleteUser{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("TheUsersPurchaseHistory")]
        public async Task<IActionResult> TheUsersPurchaseHistory(int userId)
        {
           var result = await _costumerUserService.TheUsersPurchaseHistory(userId);
            


            var jsonSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string jsonString = JsonConvert.SerializeObject(result, jsonSettings);


            if (result != null)
            {
                return Ok(jsonString);
            }
        return BadRequest();
        }

    }
}

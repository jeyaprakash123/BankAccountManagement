using BankAccountManagement.Application.Cache;
using BankAccountManagement.Application.DTO;
using BankAccountManagement.Application.Interface;
using BankAccountManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BankAccountManagement.API.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class UserController:Controller
    {
        private readonly IUserService _userService;
        private readonly RedisCacheService _redisCacheService;
        public UserController(IUserService userService, RedisCacheService redisCacheService)
        {
            _userService = userService;
            _redisCacheService = redisCacheService;
        }

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<User>> GetById([FromQuery] int id)
        {
            string cacheKey = $"user_{id}";
            var cacheResult = await _redisCacheService.GetDataAsync<UserDTO>(cacheKey);
            UserDTO user = null;
            if (cacheResult is null)
            {
                user = await _userService.GetById(id);
                if (user is null)
                {
                    return NotFound(new { Message = "User Not found" });
                }
                await _redisCacheService.SendDataAsync<UserDTO>(cacheKey, user, TimeSpan.FromMinutes(10));
            }
            var userData = cacheResult ?? user;
            return Ok(userData);
        }

        [HttpPost("add-user")]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] User user)
        {
            var res = await _userService.CreateUser(user);

            string cacheKey = $"_{res.UserId}";

            await _redisCacheService.SendDataAsync<UserDTO>(cacheKey, res, TimeSpan.FromMinutes(10));

            return CreatedAtAction(nameof(GetById), new { id = res.UserId }, res);
        }

    }
}

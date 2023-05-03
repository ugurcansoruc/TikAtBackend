using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [RequireHttps]
    [ApiController]
    [Route("api/")] //[Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [RequireHttps]
        [HttpGet("GetUser{_userID}", Name = "GetUser")]
        public User GetUser(int _userID)
        {
            return _userService.GetUserByIdAsync(_userID).Result;
        }

        [RequireHttps]
        [HttpGet("GetAllUsers", Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _userService.GetUsersAsync().Result;
        }

        [RequireHttps]
        [HttpPost("AddUser", Name = "AddUser")]
        public IActionResult AddUser(User user) 
        {
            _userService.CreateUserAsync(user);

            return Ok(user);
        }

        [RequireHttps]
        [HttpPost("UpdateUser", Name = "UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _userService.UpdateUserAsync(user);

            return Ok(user);
        }

        [RequireHttps]
        [HttpPost("DeleteUser", Name = "DeleteUser")]
        public IActionResult DeleteUser(User user) 
        {
            _userService.DeleteUserAsync(user);
            return Ok(user);
        }
    }
}
using Business.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
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
        
        [HttpGet("GetUser{_userID}" ,Name = "GetUser")]
        public User GetUser(int _userID)
        {
            return _userService.GetUserByIdAsync(_userID).Result;
        }

        [HttpGet("GetAllUsers", Name = "GetUsers")]
        public IEnumerable<User> GetUsers()
        {
            return _userService.GetUsersAsync().Result;
        }
    }
}
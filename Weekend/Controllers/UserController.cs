using Microsoft.AspNetCore.Mvc;
using Domain.Model;
using Service.abstraction;

namespace Weekend.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userservice;


        public UserController (ILogger<UserController> logger , IUserService userService)
        {
            _logger = logger;
            _userservice = userService;
        }


        [HttpGet]
        [Route("/getuser")]

        public async Task<IActionResult> GetUsers([FromQuery] string userid)
        {
            var response = new UserModel();
            try
            {
                if (userid != null)
                {
                    response = await _userservice.GetUser(userid);
                }
                else
                {
                    return StatusCode(204, "User id is null");
                }

                return Ok(response);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error in GetUser Controller :{ex.Message}");
                return StatusCode(500, "something went wrong please check the error log");
            }
            
        }

        [HttpPost]
        [Route("/edituser")]

        public async Task<IActionResult> EditUsers([FromQuery] UserModel usermodel)
        {
            var response = new DatabaseResponse();
            try
            {
                response = await _userservice.EditUser(usermodel);
            }
            catch (Exception ex)
            {
                _logger.LogError("{ex}", ex);
                return StatusCode(500, "Something went wrong, please check the logs.");
            }
            return Ok(response);
        }
    }
}

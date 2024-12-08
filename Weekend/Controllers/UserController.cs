﻿using Microsoft.AspNetCore.Mvc;
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
                response = await _userservice.GetUser(userid);

                return Ok(response);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Error in GetUser Controller :{ex.Message}");
                return StatusCode(500, "something went wrong please check the error log");
            }
            
        }
    }
}
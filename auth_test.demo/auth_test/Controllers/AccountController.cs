using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using auth_test.demo.Domain.Models;
using auth_test.demo.Domain.Services;
using auth_test.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace auth_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public AccountController(IUserService userService,IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var hashedPassword = _passwordService.ComputePasswordHash(model.Password);

            var user = _userService.Authentificate(model.Username, hashedPassword);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterModel model)
        {
            var user = (User) model;
            user.Password = _passwordService.ComputePasswordHash(model.Password);

            var savedUser = _userService.Create(user);

            if (savedUser == null)
                return BadRequest();

            return Ok(savedUser);
        }

        [Authorize(Roles =Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            
            return Ok(users);
        }
    }
}
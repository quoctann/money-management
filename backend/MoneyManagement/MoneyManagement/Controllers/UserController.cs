using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoneyMgmt.BLL;
using MoneyMgmt.Common.Request;
using MoneyMgmt.Common.Response;
using MoneyMgmt.DAL.Models;
using MoneyMgmt.Web.NonDbModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyMgmt.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            userService = new UserService();
            _config = config;
        }

        /// <summary>
        /// Get user by id on path param
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <returns>User instance information</returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.Read(id));
        }

        /// <summary>
        /// Login authenticated user with JWT token - use response token to get access authorize API
        /// </summary>
        /// <param name="login">Username and Password on JSON format</param>
        /// <returns>JWT token on response</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginInfo login)
        {
            IActionResult res = Unauthorized();

            if (!string.IsNullOrEmpty(login.Username) && !string.IsNullOrEmpty(login.Password))
            {
                User currentUser = userService.GetUserByUsername(login.Username);
                if (null != currentUser)
                {
                    if (currentUser.Password.Equals(login.Password))
                    {
                        //var tokenStr = GenerateJWT(login);
                        //res = Ok(new { token = tokenStr });
                        var jwt = new JwtServices(_config);
                        var tokenStr = jwt.GenerateSecurityToken(currentUser.Email);
                        res = Ok(new { token = tokenStr });
                    }
                }
            }

            return res;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult CreateUser([FromBody] UserInfo info)
        {
            IActionResult res = new StatusCodeResult(500);

            if (!string.IsNullOrEmpty(info.Username) && !string.IsNullOrEmpty(info.Password))
            {
                User user = new User
                {
                    Username = info.Username,
                    Password = info.Password,
                    Fullname = info.Fullname,
                    Email = info.Email,
                    IsAdmin = false,
                    IsActive = true,
                    CurrencyUnit = info.CurrencyUnit,
                };
                if (userService.RegisterUser(user))
                {
                    res = Ok();
                }
            }

            return res;
        }

        [HttpGet("deactive/{userId}")]
        public IActionResult DeactiveUser(int userId)
        {
            IActionResult res = new StatusCodeResult(500);

            if (userService.DeactiveUser(userId))
            {
                res = Ok();
            }

            return res;
        }
    }
}

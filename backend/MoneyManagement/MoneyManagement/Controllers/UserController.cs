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

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetAll(int id)
        {
            var res = new SingleResponse
            {
                Data = userService.Read(id)
            };

            return Ok(res);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginInfoModel login)
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

        /// <summary>
        /// Generate JWT token that help authorize user
        /// </summary>
        /// <param name="loginInfoModel">Login information</param>
        /// <returns>JWT Token that use for authorize</returns>
        private string GenerateJWT(LoginInfoModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                //expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }

        [HttpGet("randomly")]
        public string GetRandomToken()
        {
            var jwt = new JwtServices(_config);
            var token = jwt.GenerateSecurityToken("sample@mail.com"); ;
            return token;
        }
    }
}

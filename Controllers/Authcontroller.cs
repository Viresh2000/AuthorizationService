using AuthorizationService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AuthorizationService.Repo;
using AuthorizationService.Service;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace AuthorizationService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class Authcontroller : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(Authcontroller));
        private readonly UserService _userService;

        public Authcontroller(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginTbl user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            if (_userService.IsUserValid(user))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44349",
                    audience: "http://localhost:4200",

                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: signinCredentials
                );
               /* tokeOptions.Claims.ToList*/
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString });
            }
            else
            {
                return Unauthorized();
            }
            
        }
    }
}

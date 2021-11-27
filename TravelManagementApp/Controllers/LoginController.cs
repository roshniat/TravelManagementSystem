using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelManagementApp.Models;
using TravelManagementApp.Repository;

namespace TravelManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IConfiguration _config;
        ILoginRepository loginRepo;

        //--- dependency injection for configuration ---//
        public LoginController(IConfiguration config, ILoginRepository _l)
        {
            _config = config;
            this.loginRepo = _l;
        }

        [AllowAnonymous]
        [HttpPost]


        public IActionResult Login([FromBody] Login User)
        {
            IActionResult response = Unauthorized();



            //--- Authenticate the user ---//
            var user = AuthenticateUser(User);



            //--- validate ---//
            if (user != null)
            {
                var tokenString = GenerateJWT(user);
                response = Ok(new { Token = tokenString });
            }
            return response;
        }



        private string GenerateJWT(Login admin)
        {
            //--- getting security ---//
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            //--- signing credentials ---//
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //--- generate the token ---//
            var token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
            );



            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost]
        private Login AuthenticateUser(Login User)
        {

            Login users = null;
            var user = loginRepo.GetUser(User);
            if (user != null)
            {
                users = new Login
                {
                    UserName = User.UserName,
                    Password = User.Password
                };
            }
            return user;


        }

        public async Task<IActionResult> GetUserByUser(Login user)
        {
            try
            {
                var dbUser = loginRepo.GetUser(user);
                if (dbUser == null)
                {
                    return NotFound();
                }
                return Ok(dbUser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #region GetUser by Password
        [HttpGet("{userName}/{password}")]
        public async Task<ActionResult<Login>> GetUserByPassword(string userName, string password)
        {
            try
            {
                var tbluser = await loginRepo.GetUserByPassword(userName, password);
                if (tbluser == null)
                {
                    return NotFound();
                }
                return tbluser;



            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }
}

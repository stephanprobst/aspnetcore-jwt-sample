using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TokenService.Models;

namespace TokenService
{
    [ApiController]
    [Route("api/[controller]")]
    public partial class TokenController : Controller
    {
        private IConfiguration _config;

        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult<TokenModel> CreateToken(LoginModel login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                return Ok(new TokenModel
                {
                    Token = tokenString
                });
            }

            return Unauthorized();
        }

        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Birthdate, user.Birthdate.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                                             _config["Jwt:Issuer"],
                                            expires: DateTime.Now.AddMinutes(30),
                                            claims: claims,
                                            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.UserName == "mickey" && login.Password == "mouse")
            {
                user = new UserModel
                {
                    Name = "Mickey Mouse",
                    Email = "mickey.mouse@mydomain.com"
                };
            }
            return user;
        }
    }
}
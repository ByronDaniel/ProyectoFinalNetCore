using BP.Ecommerce.API.Utils;
using BP.Ecommerce.Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtConfiguration jwtConfiguration;

        public TokenController(IOptions<JwtConfiguration> options)
        {
            jwtConfiguration = options.Value;
        }

        [HttpPost]
        public async Task<string> TokenAsync(UserInput input)
        {
            var userTest = "foo";
            // 1. Validate User
            if (input.UserName != userTest || input.Password != "123")
            {
                throw new AuthenticationException("User or Password Incorrect!"); ;
            }
            // 2. Generate Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userTest),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", userTest)
            };
            // 3. Encript Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            
            // 4. Configure JwtSecurityToken
            var tokenDescriptor = new JwtSecurityToken(
                jwtConfiguration.Issuser,
                jwtConfiguration.Audience,
                claims,
                expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
                signingCredentials: signIn
                );

            // 5. Write and return Token
            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            return jwt;
        }
    }
}
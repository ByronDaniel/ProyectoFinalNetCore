using BP.Ecommerce.API.Utils;
using BP.Ecommerce.Application.Dtos;
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
            var userTests = new List<User> {
                new User(){UserName="Byron", Password="123", Ecuatoriano = true, Seguro = "11111", TieneLicencia = true, Roles = new List<string>(){"Admin"}},
                new User(){UserName="Maria", Password="123", Ecuatoriano = false, Seguro = "22222", TieneLicencia = true, Roles = new List<string>(){"User"}},
                new User(){UserName="Evelyn", Password="123", Ecuatoriano = false, Seguro = "33333", TieneLicencia = false, Roles = new List<string>(){"Support"} }
            };

            var userTest = userTests.Where(u => u.UserName == input.UserName && u.Password == input.Password).FirstOrDefault();
            // 1. Validate User
            if (userTest == null)
            {
                throw new AuthenticationException("User or Password Incorrect!"); ;
            }

            // 2. Generate Claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userTest.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("UserName", userTest.UserName),
                new Claim("TieneLicencia", userTest.TieneLicencia.ToString()),
                new Claim("Ecuatoriano", userTest.Ecuatoriano.ToString()),
                new Claim("Seguro", userTest.Seguro)
            };



            foreach (var rol in userTest.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }



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
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
        public bool? TieneLicencia { get; set; }
        public bool? Ecuatoriano { get; set; }
        public string? Seguro { get; set; }
    }
}
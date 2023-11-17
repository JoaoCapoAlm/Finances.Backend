using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Finances.Backend.Model;
using Microsoft.IdentityModel.Tokens;

namespace Finances.Backend.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
                return string.Empty;
            Claim[] claims =
            [
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim(ClaimTypes.DateOfBirth, user.Birth.ToString())
            ];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Finances:SymmetricSecurityKey"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(10),
                    claims: claims,
                    signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPIDemo.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;

        public TokenService(IConfiguration config)
        {
            this.config = config;
        }

        public string? GenerateToken(string username, string password, string scope)
        {
            // Normally the password would be hashed and compared to a hashed password in the database.
            // For the sake of simplicity, just check if the user/password is "admin".
            if (username != "admin" || password != "admin")
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("scope", scope)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Auth:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: config["Auth:Issuer"]!,
                audience: config["Auth:Audience"]!,
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoopCash.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CoopCash.Infra.Security
{
    public class JwtService
    {
        private readonly string _secret;
        private readonly string _issuer;

        public JwtService(IConfiguration configuration)
        {
            _secret = configuration["Jwt:Secret"] ?? throw new Exception("JWT Secret missing!");
            _issuer = configuration["Jwt:Issuer"] ?? "MyApi";
        }

        public string GenerateToken(SystemUser user)
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim("Type", user.Type.ToString())
        };

            foreach (var permission in user.Permissions)
                claims.Add(new Claim("Permission", permission));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

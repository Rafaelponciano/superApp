using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SuperApp.Application.Interfaces;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace SuperApp.Infrastructure.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(int userId, string firstName, string lastName)
    {
        var signingsCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sup3r-4pp-k3y-s3cr3t")),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken(
            issuer:"SuperApp",
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: signingsCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using JwtBearer.Models;
using Microsoft.IdentityModel.Tokens;
namespace JwtBearer.Services;

public class TokenService
{
    public string Generate(User user)
    {
        // criar uma instância do JwtSecurityTokenHandler
        var handler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(Configuration.PrivateKey);

        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key), 
        SecurityAlgorithms.HmacSha256Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddHours (2)
        };

        var token = handler.CreateToken(tokenDescriptor); // gera o token

        var strToken = handler.WriteToken(token); // gera a string do token
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SchoolLogin.Constants;

namespace SchoolLogin.Services
{
  public class TokenGenerator
  {
    /// <summary>
    /// This function is to Generate Token 
    /// </summary>
    /// <returns>A string, the token JWT</returns>

    public string Generate()
    {
      var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      var securityTokenDescriptor = new SecurityTokenDescriptor()
      {
        SigningCredentials = new SigningCredentials(
    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenConstants.Secret)),
    SecurityAlgorithms.HmacSha256Signature),
        Expires = DateTime.Now.AddDays(1)
      };
      var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
      return jwtSecurityTokenHandler.WriteToken(token);
    }
  }
}

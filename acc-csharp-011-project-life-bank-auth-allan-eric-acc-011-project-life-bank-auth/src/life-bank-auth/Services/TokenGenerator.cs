using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LifeBankAuth.Models;
using Microsoft.IdentityModel.Tokens;

namespace LifeBankAuth.Services
{
    public class TokenGenerator
    {
        public string Generate(Client client)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = AddClaims(client),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("3e35d94786e36fdc4560abf7e910c3a7")), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.Now.AddDays(5)
            };

            var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(token);
        }

        private ClaimsIdentity AddClaims(Client client)
        {
            var claimsIdentity = new ClaimsIdentity();

            var claimName = new Claim(ClaimTypes.Name, client.Name);
            var claimCurrency = new Claim(ClaimTypes.UserData, client.Currency.ToString());
            var claimType = ClientTypeEnum.PessoaFisica;

            if (client.IsCompany)
                claimType = ClientTypeEnum.PessoaJuridica;

            var claim = new Claim(ClaimTypes.Role, claimType.ToString());

            var claimsList = new List<Claim>
            {
                claimName,
                claimCurrency,
                claim
            };

            claimsIdentity.AddClaims(claimsList);

            return claimsIdentity;
        }
    }
}

using CaseStudy.Core.Common;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaseStudy.Core.Helpers
{
    public interface ITokenHelper
    {
        string CreateToken(List<Claim> claims);
    }

    public class TokenHelper: ITokenHelper
    {
        public string CreateToken(List<Claim> claims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.JWTKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            "Identity",
              claims: claims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddSeconds(3600),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

using Microsoft.IdentityModel.Tokens;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewApiService.Identity
{
    public class JwtProvider : IJwtProvider
    {
        JwtOptions jwtOptions;
        public JwtProvider(JwtOptions jwtOptions)
        {
            this.jwtOptions = jwtOptions;
        }
        public string GenerateJwtToken(Account acc)
        {
            //implement var claims etc..
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,acc.EmpId.ToString() ),
                new Claim(ClaimTypes.Role ,acc.RoleId.ToString()),
                new Claim( ClaimTypes.Name ,acc.Email ),
                new Claim(  "DateOfBirth" ,acc.DateOfBirth.Value.ToString("dd-MM-yyyy") ),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(jwtOptions.JwtExpireDays);

            var token = new JwtSecurityToken(jwtOptions.JwtIssuer, jwtOptions.JwtIssuer, claims, expires: expires, signingCredentials: creds);
            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);

        }
    }
}

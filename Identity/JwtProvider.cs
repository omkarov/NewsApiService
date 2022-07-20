using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string GenerateJwtToken(Account user)
        {
            //implement var claims etc..
            throw new NotImplementedException();
        }
    }
}

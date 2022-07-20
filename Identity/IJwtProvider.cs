using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Identity
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(Account user);

    }
}

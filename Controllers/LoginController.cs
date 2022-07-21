using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApiService.Data;
using NewApiService.Identity;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IAccountRepo accountRepo;
        IJwtProvider jwtprovider;

        public LoginController(IAccountRepo accountRepo, IJwtProvider jwtprovider)
        {
            this.accountRepo = accountRepo;
            this.jwtprovider = jwtprovider;
        }


        [HttpPost("login")]

        public ActionResult AttemptLogin([FromBody] Account acc)
        {

            string pwd = acc.Password ;
            string email = acc.Email;

            Account account = accountRepo.GetUserByEmail(email);

            if (acc == null)
            {
                return BadRequest("Invalid user name");
            }

            if (!acc.Password.Equals(pwd))
            {
                return BadRequest("Invalid Password");
            }

            var token = jwtprovider.GenerateJwtToken(acc);
            return Ok(token);

        }
    }
}

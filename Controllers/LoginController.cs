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

        PasswordManager passwordm = new PasswordManager();

        [HttpPost("login")]

        public async Task<ActionResult> AttemptLogin([FromBody] Account acc)
        {
            string pwd = acc.Password;
            string email = acc.Email;
            string hpwd = passwordm.HashPasswordEncoder(acc.Password);
            Account account = await accountRepo.GetUserByEmailAsync(email);

            if (acc == null)
            {
                return BadRequest("Invalid user name");
            }
            //if (!pwd.Equals(account.Password))
            if (!hpwd.Equals(account.Password))
            {
                return BadRequest("Invalid Password");
            }

            var token = jwtprovider.GenerateJwtToken(acc);
            return Ok(token);

        }
    }
}




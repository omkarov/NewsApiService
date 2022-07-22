using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApiService.Data;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        IAccountRepo _repo;
        public AccountController(IAccountRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllAccount")]
        public async Task<IEnumerable<Account>> GetAllUsersAsync()
        {var obj = await _repo.GetAllUserAsync();
            return obj;
        }

        [HttpGet("{id}", Name = "GetUserByIdAsync")]  
        public async Task<Account> GetUserByIdAsync(string id)
        {
            var obj = await _repo.GetUserByIdAsync(id);
            return obj;
        }


        // get user by email for checking login

        [HttpGet("GetUserByEmail/{email}", Name = "GetUserByEmail")]
        public async Task<Account> GetUserByEmailAsync(string email)
        {
            var obj= await _repo.GetUserByEmailAsync(email);
            return obj; 
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync([FromBody] Account user)
        {
           await _repo.AddUserAsync(user);

            return CreatedAtRoute(nameof(GetUserByIdAsync), new { id = user.EmpId }, user);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> deleteUserAsync(string id)
        {
            var objId =await  _repo.GetUserByIdAsync(id);
            if (objId.EmpId == null)
                return NotFound();
            else
            {
                await _repo.DeleteAccountAsync(id);
                return NoContent();   // 204 status code
            }
        }
    }
}

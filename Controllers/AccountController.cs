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



        [HttpGet("All")]
        public IEnumerable<Account> GetAllUsers()
        {
            return _repo.GetAllUser();
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public Account GetUserById(string id)
        {
            return _repo.GetUserById(id);
        }


        [HttpPost]
        public ActionResult AddUser([FromBody] Account user)
        {
            _repo.AddUser(user);

            return CreatedAtRoute(nameof(GetUserById), new { id = user.EmpId }, user);
        }

        [HttpDelete("{id}")]

        public ActionResult deleteUser(string id)
        {
            var objId = _repo.GetUserById(id);
            if (objId.EmpId == null)
                return NotFound();
            else
            {
                _repo.DeleteAccount(id);
                return NoContent();   // 204 status code
            }
        }
    }
}

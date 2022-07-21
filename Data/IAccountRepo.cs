using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public interface IAccountRepo
    {
        IEnumerable<Account> GetAllUser();
        Account GetUserById(string Id);
        Account GetUserByEmail(string email);
        void AddUser(Account user);
        void DeleteAccount(string Id);
    }
}

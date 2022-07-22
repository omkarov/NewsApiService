using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public interface IAccountRepo
    {
        Task<IEnumerable<Account>> GetAllUserAsync();
        Task<Account> GetUserByIdAsync(string Id);
        Task<Account> GetUserByEmailAsync(string email);
        Task AddUserAsync(Account user);
        Task DeleteAccountAsync(string Id);
    }
}

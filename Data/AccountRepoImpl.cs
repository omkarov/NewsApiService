using NewApiService.DAL;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public class AccountRepoImpl:IAccountRepo
    {
        DBUtility dbutility = new DBUtility();
        ASCIIEncoding ascii = new ASCIIEncoding();

        public async Task<IEnumerable<Account>> GetAllUserAsync()
        {
            //return userList;
            var obj = await dbutility.UtilitygetAllUsersAsync();
            return obj;
        }

        public async Task<Account> GetUserByIdAsync(string Id)
        {
            //return userList.FirstOrDefault(x => x.EmpId.Equals(Id));
            var obj = await dbutility.UtilityGetUserByIdAsync(Id);
            return obj;
        }

        public async Task<Account> GetUserByEmailAsync(string email)
        {
            var obj = await dbutility.UtilityGetUserByEmailAsync(email);
            return obj ;
        }

        public async Task AddUserAsync(Account user)
        {
            if (user != null)
            {
                //userList.Add(user);
                await dbutility.UtilityAddAccountAsync(user);
            }
        }

        public async Task DeleteAccountAsync(string Id)
        {
                await dbutility.UtilityDeleteAccountAsync(Id);
            
        }


        // hashing password
        public string HashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            string hashedPassword = ascii.GetString(md5data);

            return hashedPassword;
        }

        //List<Role> roleList = new List<Role>()
        //{
        //    new Role { RoleId =1 ,RoleName="Admin"},
        //    new Role { RoleId =2 ,RoleName="Employee"  },
        //    };

        //List<Account> userList = new List<Account>()
        //{
        //    new Account { EmpId ="N1110" ,Name="John Doe",Email="john@mail.com", Password="pass123",RoleId=1,DateOfBirth=new DateTime(2022,07,20) ,Nationality="Indian",NewsCount=5,UserIsApprovedByAdmin=true },
        //    new Account { EmpId ="N2220" ,Name="Sick Doe",Email="sick@mail.com", Password="pass123",RoleId=2,DateOfBirth=new DateTime(2022,07,20) ,Nationality="German",NewsCount=15,UserIsApprovedByAdmin=true },
        //    new Account { EmpId ="N3330" ,Name="Alice Forsaken",Email="alice@mail.com", Password="pass123",RoleId=2,DateOfBirth=new DateTime(2022,07,20) ,Nationality="Spain",NewsCount=25,UserIsApprovedByAdmin=true },
        //    new Account { EmpId ="N4440" ,Name="Mary Doe",Email="mary@mail.com", Password="pass123",RoleId=2,DateOfBirth=new DateTime(2022,07,20) ,Nationality="UK",NewsCount=35,UserIsApprovedByAdmin=true },
        //    new Account { EmpId ="N5550" ,Name="Steel Hiko",Email="steel@mail.com", Password="pass123",RoleId=1,DateOfBirth=new DateTime(2022,07,20) ,Nationality="American",NewsCount=45,UserIsApprovedByAdmin=true }
        //};

    }
}

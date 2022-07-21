using NewApiService.DAL;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Data
{
    public class AccountRepoImpl:IAccountRepo
    {
        DBUtility dbutility = new DBUtility();

        public IEnumerable<Account> GetAllUser()
        {
            //return userList;
            return dbutility.UtilitygetAllUsers();
        }

        public Account GetUserById(string Id)
        {
            //return userList.FirstOrDefault(x => x.EmpId.Equals(Id));
            return dbutility.UtilityGetUserById(Id);
        }

        public Account GetUserByEmail(string email)
        {
            return dbutility.UtilityGetUserByEmail(email);
        }

        public void AddUser(Account user)
        {
            if (user != null)
            {
                //userList.Add(user);
                dbutility.UtilityAddAccount(user);
            }
        }

        public void DeleteAccount(string Id)
        {
            
                dbutility.UtilityDeleteAccount(Id);
            
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

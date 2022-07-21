using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewApiService.Model
{
    public class PasswordManager
    {
        ASCIIEncoding ascii = new ASCIIEncoding();

        public string HashPasswordEncoder(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            string hashedPassword = ascii.GetString(md5data);

            return hashedPassword;
        }

        public void HashPasswordecodeer(string hashedPassword)
        {
            var data = Encoding.ASCII.GetBytes(hashedPassword);
            var md5 = new MD5CryptoServiceProvider();

            var md5data = md5.ComputeHash(data);

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SR
{
    public class User
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserRegistry
    {
            private List<User> Users = new List<User>();
            public bool Registry(User user)
            {
                if (user.Email.Length > 0 && user.Password.Length >= 8)
                {
                    //Encriptar Passw   
                    //var encoding = Encoding.UTF8.GetBytes(user.Password);
                    //var sha256=SHA256.HashData(encoding);
                    //var passwordEncripted = Convert.ToHexString(sha256);

                    var passwEncripted = EncryptionService.Encrypt(user.Password);

                    Users.Add(new User()
                    {
                        Email = user.Email,
                        Password = passwEncripted,
                    }); 
                return true;
                }
                return false;
            }
    }


    public class EncryptionService
    {
        public static string Encrypt(string input)
        {
            var encoding = Encoding.UTF8.GetBytes(input);
            var sha256 = SHA256.HashData(encoding);
            var dataEncripted = Convert.ToHexString(sha256);
            return dataEncripted;
        }
    }


}

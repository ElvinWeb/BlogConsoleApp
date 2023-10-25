using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Models
{
    public static class UserService
    {

        public static void Register(string name, string surname, string password)
        {
            BlogDataBase.Users.Add(new User(name, surname, password));
        }

        public static bool Login(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }

            foreach (User user in BlogDataBase.Users)
            {
                if (user.Password.ToLower() == password.ToLower() && user.Username.ToLower() == username.ToLower())
                {
                    return true;
                }

            }
            return false;
        }
    }
}

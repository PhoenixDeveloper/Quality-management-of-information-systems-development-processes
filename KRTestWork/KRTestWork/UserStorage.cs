using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRTestWork
{
    class UserStorage
    {
        private static List<User> userStorage;
        private static User currentUser;

        public static void AddUser(User user)
        {
            userStorage.Add(user);
        }

        public static bool Login(User user)
        {
            bool trueLogin = false;
            foreach (var element in userStorage)
            {
                if (user.login == element.login)
                {
                    trueLogin = true;
                    if (user.password == element.password)
                    {
                        Console.WriteLine("Access granted");
                        currentUser = user;
                        return true;
                    }
                }
            }
            if (trueLogin)
            {
                Console.WriteLine("Password incorrect");
            }
            else
            {
                Console.WriteLine("Access denied");
            }
            return false;
        }
    }
}

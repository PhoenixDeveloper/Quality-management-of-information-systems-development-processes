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

        public static void AddUser(User user)
        {
            userStorage.Add(user);
        }
    }
}

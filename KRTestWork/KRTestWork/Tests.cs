using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRTestWork
{
    class Tests
    {
        public void TestCreateUser()
        {
            User user = new User("login", "password");
        }

        public void TestAddUser()
        {
            UserStorage.AddUser(new User("login", "password"));
        }

        public void TestLoginUser()
        {
            if (UserStorage.Login(new User("login", "password")))
            {
                Console.WriteLine("Access granted");
            }
            else
            {
                Console.WriteLine("Access denied");
            }
        }

        public void TestDeleteUser()
        {
            User user = new User("login", "password");

            UserStorage.DeleteUser(user, "password");
        }
    }
}

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
            UserStorage.addUser(new User("login", "password"));
        }
    }
}

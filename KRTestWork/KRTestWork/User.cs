using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRTestWork
{
    class User
    {
        public readonly string login;
        public readonly string password;

        public User(string login, string password, bool isNeedHash = true)
        {
            this.login = login;
            this.password = isNeedHash ? UserStorage.HashPassword(password) : password;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRTestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests tests = new Tests();
            tests.TestCreateUser();
            tests.TestAddUser();
            tests.TestLoginUser();
            tests.TestDeleteUser();
            tests.TestChangeNameFile();
            Console.ReadKey();
        }
    }
}

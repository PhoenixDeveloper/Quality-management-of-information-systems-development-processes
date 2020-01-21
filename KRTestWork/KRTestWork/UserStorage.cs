using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KRTestWork
{
    class UserStorage
    {
        private static List<User> userStorage = new List<User>();
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

        public static void DeleteUser(User user, string password)
        {
            if (user.password == password)
            {
                if (userStorage.Contains(user))
                {
                    userStorage.Remove(user);
                    Console.WriteLine("Delete user");
                }
                else
                {
                    Console.WriteLine("User doesn't exist");
                }
            }
            else
            {
                Console.WriteLine("Password incorrect");
            }
        }

        public static void ReadFile(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader($@"{path}", Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] userStringArray = line.Split('-');
                        UserStorage.AddUser(new User(userStringArray[0], userStringArray[1]));
                    }
                }
                Console.WriteLine("Чтение выполнено");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

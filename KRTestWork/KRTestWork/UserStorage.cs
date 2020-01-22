using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Data.Services;

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

        public static bool Login(string login, string password)
        {
            bool trueLogin = false;
            foreach (var element in userStorage)
            {
                if (login == element.login)
                {
                    trueLogin = true;
                    if (VerifyHashedPassword(element.password, password))
                    {
                        Console.WriteLine("Access granted");
                        currentUser = element;
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
            if (VerifyHashedPassword(user.password, password))
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
                        UserStorage.AddUser(new User(userStringArray[0], userStringArray[1], false));
                    }
                }
                Console.WriteLine("Чтение выполнено");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        private static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }
            return ByteArraysEqual(buffer3, buffer4);
        }

        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
    }
}

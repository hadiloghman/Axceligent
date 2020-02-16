using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var user = new User();
                Console.WriteLine("please enter the username, or q to exit");
                var userName = Console.ReadLine();
                if (userName == "q")
                {
                    break;
                }

                user.Add(userName);
                Console.WriteLine($"number of addedUser {user.GetUsersCount()}");
            }
        }

        class User
        {
            string[] lstUsers;
            public User()
            {
                this.lstUsers = new string[0];
            }

            public void Add(string userName)
            {
                Array.Resize(ref this.lstUsers, this.lstUsers.Length + 1);
                this.lstUsers[this.lstUsers.Length - 1] = userName;
            }

            public int GetUsersCount()
            {
                return this.lstUsers.Length;
            }
        }
    }
}

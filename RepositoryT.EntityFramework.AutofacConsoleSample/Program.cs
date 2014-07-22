using System;
using RepositoryT.EntityFramework.SimpleBusiness.Entities;
using RepositoryT.EntityFramework.SimpleBusiness.Service;

namespace RepositoryT.EntityFramework.AutofacConsoleSample
{
    public class Program
    {
        public static void Main()
        {
            IUserService userService = IoC.Resolve<IUserService>();
            User user1 = new User
                             {
                                 Email = "someone@somehost.com",
                                 FirstName = "Ziyasal",
                                 LastName = "Doe"
                             };
            userService.AddUser(user1);
            User user2 = new User
                             {
                                 Email = "someone@somehost.com",
                                 FirstName = "John",
                                 LastName = "Doe"
                             };
            userService.AddUser(user2);

            foreach (User user in userService.GetAll())
            {
                Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
            }

            Console.Read();
        }
    }

}

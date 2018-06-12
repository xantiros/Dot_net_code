using Dot_net_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dot_net_core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var par = new Paralellism();
            par.Test();

            //var asy = new Asynchronous();
            //asy.Test().Wait();

            /*
            var text = "abc";

            if(text.NotEmpty())
            {
                Console.WriteLine("Hello Darknes my old friend");
            }
            */

            /*
            List<User> users = new List<User>();
            var differentUsers = users.Select(x => new
            {
                Email = x.Email
            });
            foreach(var differentUser in differentUsers)
            {
                Console.WriteLine(differentUser.Email); 
            }
            */

            //Exceptions exceptions = new Exceptions();
            //exceptions.Test();


            //Race race = new Race();
            //race.Begin();

            /*
            User user = new User("email@com", "haslo");
            user.Activate();
            Order order1 = new Order(1, 10);
            user.IncreaseFunds(100);
            user.PurchaseOrder(order1);

            //badUser.Email = "a";
            Console.WriteLine(user.Funds);
            */

            Console.ReadKey();
        }
   
    }
}

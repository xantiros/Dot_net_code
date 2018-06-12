using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dot_net_core.Models
{
    class Reflections
    {
        //badać typy w trakcie działania aplikacji

        public void Test()
        {
            var user = new User("user@gmail.com", "secret");
            var type = user.GetType(); // pobieram typ
            Console.WriteLine($"{type.Name} {type.Namespace} {type.FullName}");
            var methods = type.GetMethods();
            foreach (var item in methods)
            {
                //Console.WriteLine(item.Name);
            }
            user.Activate();
            Console.WriteLine($"Is active: {user.IsActive}.");

            var deactivateMethod = methods.First(x => x.Name == "Deactivate");
            deactivateMethod.Invoke(user, null);
            Console.WriteLine($"Is active: {user.IsActive}.");

            Console.WriteLine(user.Email);
            var setemail = type.GetMethod("SetEmail");
            setemail.Invoke(user, new[]{"user2@gmail.com"});
            Console.WriteLine(user.Email);

            var email = type.GetProperty("Email").GetValue(user);
            Console.WriteLine(email);

            var databaseTypes = Assembly.GetEntryAssembly().GetTypes().Where(x => x.Name.Contains("Database"));

            foreach (var item in databaseTypes)
            {
                Console.WriteLine(item);
            }

            var user2 = Activator.CreateInstance(typeof(User), new[] { "user@df.com", "secret" });
            //Console.WriteLine(user2.Email);
            Console.WriteLine($"{type.GetProperty("Email").GetValue(user2) as string}");
        }
    }

    public class Dynamics //wykorzystyewane przy połączeniach z bazą danych
    {
        public void Test()
        {
            dynamic user = new User("user1@gmail.com", "secret");
            Console.WriteLine(user.Email);
            user.SetEmail("user2gmail.com");
            Console.WriteLine(user.Email);

            dynamic anything = new ExpandoObject(); //ampowanie string i object
            anything.id = 1;
            anything.name = "me";

            Console.WriteLine($"{ anything.id} { anything.name}");

            foreach (var item in anything)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }

    public class Attributes
    {
        public void Test()
        {
            var user = new User("user@gmail.com", "secr");
            var passwordAttribute = (UserPasswordAttribute)user.GetType()
                .GetTypeInfo()
                .GetProperty("Password")
                .GetCustomAttribute(typeof(UserPasswordAttribute));

            var isPasswordValid = user.Password.Length == passwordAttribute.Length;
            Console.WriteLine(isPasswordValid);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UserPasswordAttribute : Attribute
    {
        public int Length { get; }

        public UserPasswordAttribute(int length = 4)
        {
            Length = length;
        }
    }

    public class Asynchronous
    {
        public async Task Test() //zamiast voida uzywamy Task-a, voida tylko jak chcemy: fire and forget ( czyli uruchamiam i cos sie wykonuje w tle
        {
            var content = await GetContentAsync();
            Console.WriteLine(content);
        }

        public async Task<string> GetContentAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
            //var tast = httpClient.GetAsync("https://jsonplaceholder.typicode.com/photos");
            var content = await response.Content.ReadAsStringAsync();

            return content;

        }
    }

    public class Paralellism
    {
        public void Test()
        {
            var numbers = Enumerable.Range(1, 100);
            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Number {number} on threat {Thread.CurrentThread.ManagedThreadId}");
                //Thread.Sleep(100);
            });
        }
    }

}

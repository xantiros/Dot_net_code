using System;
using System.Collections.Generic;
using System.Text;

namespace Dot_net_core.Models
{
    class Exceptions
    {
        public void Test()
        {
            try
            {
                User user = new User("user@gmail.com", "Secret");
                user = null;
                throw new ArgumentNullException(nameof(user));
                //logika
                //throw new Exception("Email in use.");
            }
            catch(ArgumentNullException exception)
            {
                Console.WriteLine($"Null error: {exception}");
            }
            catch (Exception exception)
            {
                //Exception exception = new Exception("Parent", new Exception("Child"));
                //throw exception;
                Console.WriteLine($"An error: {exception}");
            }
            finally
            {
                //Dispose()
            }
            Console.WriteLine("OK");
        }
    }
}

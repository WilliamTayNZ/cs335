using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { FirstName = "Carolyn", LastName = "Smith" };
            person.LastName = "Jones";
            Console.WriteLine("New Lastname {0}", person.LastName);
            person.FirstName = "Carlos";
            Console.WriteLine("New Firstname {0}", person.FirstName);
        }
    }
}

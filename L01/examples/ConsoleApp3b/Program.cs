using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person { LastName = "Smith" };
            Console.WriteLine("Initial Lastname {0}", person.LastName);
            //person.LastName = "";
            person.LastName = "Jones";
            Console.WriteLine("New Lastname {0}", person.LastName);
        }
    }
}

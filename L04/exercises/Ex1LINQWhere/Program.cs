using System.Linq;

namespace Ex1LINQWhere
{

    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Person> people = new List<Person>

            { new Person { Name = "Bob", Age = 35 },
              new Person { Name = "Mbappe", Age = 27 },
              new Person { Name = "Charlie", Age = 40 }
            };

            IEnumerable<Person> peopleOver30 = people.Where(p => p.Age > 30);

            Console.WriteLine("Persons older than 30:");
            foreach (Person person in peopleOver30)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}

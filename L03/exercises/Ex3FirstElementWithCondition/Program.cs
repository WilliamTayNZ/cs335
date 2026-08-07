namespace Ex3FirstElementWithCondition;

class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "Alice", Age = 25},
            new Person { Name = "Cary", Age = 21},
            new Person { Name = "Bob", Age = 35 },
            new Person { Name = "Danny", Age = 40},
        };

        Person? firstPerson = people.FirstOrDefault(p => p.Age > 30);

        if (firstPerson is not null) {
            Console.WriteLine($"First person over 30: {firstPerson.Name}, Age: {firstPerson.Age}");
        } else
        {
            Console.WriteLine("No person found with age greater than 30");
        }


    }
}

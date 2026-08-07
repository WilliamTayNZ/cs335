using AnimalSounds.Data;
using AnimalSounds.Models;
using System.Collections.Generic;

namespace AnimalSounds;

class Program
{
    static void Main(string[] args)
    {
        List<IAnimal> animals = new List<IAnimal>();
        animals.Add(new Cat());
        animals.Add(new Cow());
        animals.Add(new Dog());

        foreach(IAnimal animal in animals)
        {
            Console.WriteLine(animal.GetName());
            Console.WriteLine(animal.MakeSound());
            Console.WriteLine(animal.GetDescription());
        }
    }
}

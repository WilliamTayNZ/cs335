using Ex3AnimalSounds.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3AnimalSounds.Models
{
    internal class Dog : IAnimal
    {
        public string MakeSound()
        {
            return "Woof!";
        }

        public string GetName()
        {
            return "Buddy";
        }

        public string GetDescription()
        {
            return "A loyal and friendly canine companion";
        }
    }
}

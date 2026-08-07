using Ex3AnimalSounds.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3AnimalSounds.Models
{
    internal class Cat : IAnimal
    {
        public string MakeSound()
        {
            return "Meow!";
        }

        public string GetName()
        {
            return "Tom";
        }

        public string GetDescription()
        {
            return "An independent feline with soft fur";
        }
    }
}

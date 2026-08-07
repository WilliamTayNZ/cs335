using Ex3AnimalSounds.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3AnimalSounds.Models
{
    internal class Cow : IAnimal
    {
        public string MakeSound()
        {
            return "Moo!";
        }

        public string GetName()
        {
            return "Coo";
        }

        public string GetDescription()
        {
            return "A gentle cow that produces milk";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex3AnimalSounds.Data
{
    interface IAnimal
    {
        string MakeSound();
        string GetName();
        string GetDescription();
    }
}

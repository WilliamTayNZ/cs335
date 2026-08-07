using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1Vehicle
{
    internal class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public string? Type { get; set; }

        public void Drive() {
            Console.WriteLine("Driving the car...");
        }
    }
}

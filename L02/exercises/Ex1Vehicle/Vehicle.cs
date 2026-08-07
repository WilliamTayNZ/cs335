using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1Vehicle
{
    internal class Vehicle
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public int Year { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine("Make: {0}, Model = {1}, Year = {2}", Make, Model, Year);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1Vehicle
{
    internal class Motorcycle : Vehicle
    {
        public double EngineSize { get; set; }
        
        public void Ride()
        {
            Console.WriteLine("Riding the motorcycle...");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Person
    {
        public string FirstName { get; } = "Carolyn";

        // Backing field for LastName
        private string _lastName; 

        // Property with custom setter
        public string LastName
        {
            get { return _lastName; }
            set
            {
                // Validate that the value is not null or empty
                if (!string.IsNullOrEmpty(value))
                {
                    _lastName = value; // Set the backing field
                }
                else
                {
                    Console.WriteLine("Error: LastName cannot be null or empty.");
                }
            }
        }
    }
}

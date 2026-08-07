using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqOrderEx
{
    class Program
    {
        static void Main(string[] args)
        {
            MockCustomerRepo repo = new MockCustomerRepo();
            IEnumerable<Customer> customers = repo.GetAllCustomers();
            IEnumerable<Customer> sortedCustomers1 = customers.OrderBy(e => e.LastName);
            foreach (Customer c in sortedCustomers1)
                Console.WriteLine("Name: {0} {1}", c.FirstName, c.LastName);
            IEnumerable<Customer> sortedCustomers2 = customers.OrderBy(e => e.LastName).ThenBy(e=>e.FirstName);
            foreach (Customer c in sortedCustomers2)
                Console.WriteLine("Name: {0} {1}", c.FirstName, c.LastName);
            IEnumerable<Customer> sortedCustomers3 = customers.OrderByDescending(e => e.Id);
            foreach (Customer c in sortedCustomers3)
                Console.WriteLine("ID: {0}  Name: {1} {2}", c.Id, c.FirstName, c.LastName);
            IEnumerable<Customer> sortedCustomers4 = customers.OrderByDescending(e => e.LastName).ThenByDescending(e=>e.Id);
            foreach (Customer c in sortedCustomers4)
                Console.WriteLine("ID: {0}  Name: {1} {2}", c.Id, c.FirstName, c.LastName);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationEx3.Model;

namespace AuthenticationEx3.Data
{
    public interface IAuthRepo
    {
        public IEnumerable<Customer> GetAllCustomers();
        public bool ValidLogin(string userName, string password);
        public Customer GetCustomerByEmail(string e);
    }
}

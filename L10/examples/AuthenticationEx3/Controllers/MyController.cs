using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuthenticationEx3.Data;
using AuthenticationEx3.Dto;
using AuthenticationEx3.Model;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AuthenticationEx3.Controllers
{
    [Route("api")]
    [ApiController]
    public class MyController : Controller
    {
        private readonly IAuthRepo _repository;

        public MyController(IAuthRepo repository)
        {
            _repository = repository;
        }

        // GET api/ViewCustomer
        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AuthOnly")]
        [HttpGet("ViewCustomer")]
        public ActionResult<CustomerOutputDto> ViewCustomer()
        {
            Claim claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            if (claim == null)
            {
                return Forbid();
            }
            string email = claim.Value.ToString();
            Customer customer = _repository.GetCustomerByEmail(email);
            CustomerOutputDto cOut = new CustomerOutputDto { FirstName = customer.FirstName, LastName = customer.LastName, Email = customer.Email, Password = customer.Password };
            return Ok(cOut);
        }

        // GET api/ListAllCustomers
        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "AdminOnly")]
        [HttpGet("ListAllCustomers")]
        public ActionResult<IEnumerable<CustomerOutputDto>> ListAllCustomers()
        {
            IEnumerable<Customer> customers = _repository.GetAllCustomers();
            IEnumerable<CustomerOutputDto> cOut = customers.Select(e => new CustomerOutputDto { FirstName = e.FirstName, LastName = e.LastName, Email=e.Email,Password=e.Password });
            return Ok(cOut);
        }
    }
}

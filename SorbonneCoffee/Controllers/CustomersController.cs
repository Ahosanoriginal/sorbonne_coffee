using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using SorbonneCoffee.Models;
using SorbonneCoffee.Services;

namespace SorbonneCoffee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService, AccountService accountService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> Get() =>
            _customerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer customer)
        {
            var account = _accountService.Get(customer.AccountId);

            if (account == null)
            {
                return StatusCode(500, new { message = "The specified accountId doesn't exist" });
            }
            _customerService.Create(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.Id.ToString() }, customer);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Customer customerIn)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Update(id, customerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerService.Remove(customer.Id);

            return NoContent();
        }
    }
}
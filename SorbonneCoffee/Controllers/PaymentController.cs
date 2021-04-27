using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using SorbonneCoffee.Models;
using SorbonneCoffee.Services;

namespace SorbonneCoffee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentsController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<List<Payment>> Get() =>
            _paymentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPayment")]
        public ActionResult<Payment> Get(string id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public ActionResult<Payment> Create(Payment payment)
        { 
            _paymentService.Create(payment);

            return CreatedAtRoute("GetPayment", new { id = payment.Id.ToString() }, payment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Payment paymentIn)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Update(id, paymentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Remove(payment.Id);

            return NoContent();
        }
    }
}
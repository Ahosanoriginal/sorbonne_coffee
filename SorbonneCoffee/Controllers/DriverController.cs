using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using SorbonneCoffee.Models;
using SorbonneCoffee.Services;

namespace SorbonneCoffee.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly DriverService _driverService;

        public DriversController(DriverService driverService, AccountService accountService)
        {
            _accountService = accountService;
            _driverService = driverService;
        }

        [HttpGet]
        public ActionResult<List<Driver>> Get([FromQuery] bool? available = true)
        {
            return available != null ? _driverService.Get(available) : _driverService.Get();
        }
          

        [HttpGet("{id:length(24)}", Name = "GetDriver")]
        public ActionResult<Driver> Get(string id)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        [HttpPost]
        public ActionResult<Driver> Create(Driver driver)
        {
            var account = _accountService.Get(driver.AccountId);

            if (account == null)
            {
                return StatusCode(500, new { message = "The specified accountId doesn't exist" });
            }
            _driverService.Create(driver);

            return CreatedAtRoute("GetDriver", new { id = driver.Id.ToString() }, driver);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Driver driverIn)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            _driverService.Update(id, driverIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var driver = _driverService.Get(id);

            if (driver == null)
            {
                return NotFound();
            }

            _driverService.Remove(driver.Id);

            return NoContent();
        }
    }
}
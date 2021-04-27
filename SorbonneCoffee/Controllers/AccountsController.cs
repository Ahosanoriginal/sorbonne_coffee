using System;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SorbonneCoffee.Models;
using SorbonneCoffee.Services;

namespace SorbonneCoffee.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountsController(AccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet("{id:length(24)}", Name = "GetAccount")]
        public ActionResult<Account> Get(string id)
        {
            var account = _accountService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Account> Create(Account account)
        {
            if (_accountService.GetByEmail(account.Email) != null)
            {
                return StatusCode(409, new { message = "Email is already used." });
            }

            account.Password = HashPassword(account.Password);

            _accountService.Create(account);

            return CreatedAtRoute("GetAccount", new
            {
                id = account.Id.ToString()
            }, account);

        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Account accountIn)
        {
            var account = _accountService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            accountIn.Password = HashPassword(accountIn.Password);

            _accountService.Update(id, accountIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var account = _accountService.Get(id);

            if (account == null)
            {
                return NotFound();
            }

            _accountService.Remove(account.Id);

            return NoContent();
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}
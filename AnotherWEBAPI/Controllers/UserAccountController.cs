using System.Collections.Generic;
using System.Web.Http;
using AnotherWEBAPI.Data;
using System;
using AnotherWEBAPI.Models;

namespace AnotherWEBAPI.Controllers
{
    public class UserAccountController : ApiController
    {
        private IAccountRepository _accountRepository;

        public UserAccountController(IAccountRepository accountRepository)
        {
            if (accountRepository == null)
            {
                throw new ArgumentNullException("accountRepository");
            }
            _accountRepository = accountRepository;
        }

        // GET: api/UserAccount
        public IEnumerable<UserAccount> Get()
        {
            return _accountRepository.GetAll();
        }
            
        // GET: api/UserAccount/5
        public UserAccount Get(int id)
        {
            return _accountRepository.GetUserAccount(id);
        }

        // POST: api/UserAccount
        public IHttpActionResult Post(UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _accountRepository.Add(userAccount);

            return CreatedAtRoute("DefaultApi", new { id = userAccount.Id }, userAccount);
        }

        // PUT: api/UserAccount/5
        public IHttpActionResult Put(int id, UserAccount userAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id  != userAccount.Id)
            {
                return BadRequest();
            }

            _accountRepository.Update(userAccount);

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: api/UserAccount/5
        public IHttpActionResult Delete(int id)
        {
            UserAccount userAccount = _accountRepository.GetUserAccount(id);
            if (userAccount == null)
            {
                return NotFound();
            }

            _accountRepository.Remove(id);

            return Ok(userAccount);
        }
    }
}

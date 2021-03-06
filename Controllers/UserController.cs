using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;
using BookingSystemApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        #region Private Variable
        
        public IUserRepository Repo;
        #endregion
        public UserController(IUserRepository service)
        {
        
            this.Repo=service;
        }

        public async Task<IActionResult> Get()
        {
            var vm = new UserViewModel(Repo);
            var data= await vm.GetUsers();
            return   Ok(data);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserModel user)
        {
            Console.WriteLine(user.Email);
            // Console.WriteLine("read");
            var vm = new UserViewModel(this.Repo);
            user= await vm.RegisterUser(user);
            return Ok(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

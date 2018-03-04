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
        #region Private Varible
        UserViewModel _userViewModel;
        public IUserRepository Repo { get; set; }
        #endregion
        public UserController(IUserRepository userViewModel)
        {
            //this._userViewModel=new UserViewModel(Repo);
            this.Repo=userViewModel;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data= await this.Repo.GetAll();
            return   Ok(data);
        }
        // public async Task<IActionResult> Get()
        // {
        //     this._userViewModel= new UserViewModel(Repo);
        //     var data= await this._userViewModel.GetUsers();
        //     return   Ok(data);
        // }
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
            // Console.WriteLine("read");
            // this._userViewModel.RegisterUser(user);
            user= await this.Repo.Add(user);
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

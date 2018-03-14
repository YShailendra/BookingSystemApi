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
    public class BookingController : Controller
    {
        #region Private Property
        private IBookingRepository _bookingRepo;
        #endregion
        public BookingController(IBookingRepository iUserRepository)
        {
            this._bookingRepo=iUserRepository;
        }
        public BookingController()
        {
            
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BookingModel value)
        {
            var vm=new BookingViewModel(_bookingRepo);
             var result= vm.SaveBookingDetails(value);
            if(result=="success")
            {
                return Ok(result);    
            }
            else
            {
                return Ok(result);
            }
            
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

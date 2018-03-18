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
    public class BusContoller : Controller
    {
        #region Private Property
        private IBusRepository _busRepo;
        #endregion
        public BusContoller(IBusRepository busRepo)
        {
            this._busRepo=busRepo;
        }
        public BusContoller()
        {
            
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<BusDetailModel> Get()
        {
            var vm = new BusViewModel(this._busRepo);
            return vm.GetBusDetails();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
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

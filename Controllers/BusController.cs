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
    public class BusController : Controller
    {
        #region Private Property
        private IBusRepository _busRepo;
        private IBookingRepository bookingRepository;
        #endregion
        public BusController(IBusRepository busRepo,IBookingRepository booking)
        {
            this._busRepo=busRepo;
            this.bookingRepository=booking;
        }
        
        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookingModel data)
        {
            var vm = new BusViewModel(this._busRepo);
            var result= await vm.GetBusDetails(data);
            return  Ok(result);
        }

        // GET api/Bus/GetStation
        [HttpGet("GetStation")]
        public  IActionResult GetStation(string name="")
        {
            var vm = new BusViewModel(this._busRepo);
            return  Ok(vm.GetStation(name).Result);
        }
                // GET api/Bus/GetRoute
        [HttpGet("GetRoute")]
        public  IActionResult GetRoute(string name="")
        {
            var vm = new BusViewModel(this._busRepo);
            return  Ok(vm.GetRoute(name).Result);
        }

        [HttpGet("GetBusByRouteId")]
        public  IActionResult GetBusByRouteId(string routeid="")
        {
            var vm = new BusViewModel(this._busRepo);
            return  Ok(vm.GetBusByRouteId(routeid).Result);
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

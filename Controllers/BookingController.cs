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
        // GET api/booking
        [HttpPost("GetBookedSeats")]
        public IActionResult Get([FromBody]BookingModel model)
        {
              var vm=new BookingViewModel(_bookingRepo);
             var result= vm.GetBookedSeats(model);
             return Ok(result.Result);
        }

        // GET api/Booking/GetBookingByBookingNumber
        [HttpGet("GetBookingByBookingNumber")]
        public async Task<IActionResult> Get(string bookingnumber,string email)
        {
             var vm=new BookingViewModel(_bookingRepo);
             var result=await vm.GetBookingDetails(bookingnumber,email);
             return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]BookingModel value)
        {
            try
            {
             var vm=new BookingViewModel(_bookingRepo);
             var result= vm.SaveBookingDetails(value);
             return Ok(result);
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
            
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]BookingModel value)
        {
             var vm=new BookingViewModel(_bookingRepo);
             var result= vm.CancelAndConfirmBooking(value,2);
             return Ok(result);
        }

        // PUT api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
             var vm=new BookingViewModel(_bookingRepo);
             var result= await vm.GetBookingById(id);
             return Ok(result);
        }
    }
}

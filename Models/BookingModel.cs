using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    public class BookingModel:BaseModel
    {
        public string Name { get; set;}
        public string Email {get; set;}
        public string Source {get; set;}
        public string Destination {get; set;}
        public string PhoneNo {get; set;}
        public string BookingNumber {get; set;}
        public string BookedSeats {get; set;}
        public int? AmountPaid {get; set;}
        public int? CancelationCharge {get; set;}
    }
}
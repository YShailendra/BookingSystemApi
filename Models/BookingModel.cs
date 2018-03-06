using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    public class BookingModel:BaseModel
    {
        [Required]
        public string Name { get; set;}
        
        [Required]
        public string Email {get; set;}
        [Required]
        public string Source {get; set;}
        [Required]
        public string Destination {get; set;}
        [Required]
        public string PhoneNo {get; set;}
        [Required]
        public string BookingNumber {get; set;}
        [Required]
        public string BookedSeats {get; set;}
        public int? AmountPaid {get; set;}
        public int? CancelationCharge {get; set;}
        [Required]
        public DateTime JourneyDate { get; set;}
        public Guid? BusID {get; set;}
    }
}
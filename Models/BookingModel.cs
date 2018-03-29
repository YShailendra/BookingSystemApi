using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    [Table("Booking")]
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
        
        public int TotalAmount { get; set;}
        public int? AmountPaid {get; set;}
        public int? CancelationCharge {get; set;}
        [Required]
        public DateTime JourneyDate { get; set;}
        public Guid? BusID {get; set;}
        public Boolean Status {get; set;}
        public List<SeatDetails> BookedSeatDetails {get; set;}
    }
}
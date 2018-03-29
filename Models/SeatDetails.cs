using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Models
{
    public class SeatDetails
    {
        public Guid ID { get; set; }
        public string SeatId { get; set;}
        [Required]
        public string SeatType {get; set;}
        [Required]
        public string Gender {get; set;}
        public int Amount {get; set;}
        public BookingModel Booking {get ; set;}
    }
}
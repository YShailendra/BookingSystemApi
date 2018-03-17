using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Models
{
    public class SeatDetails
    {
        public string SeatId { get; set;}
        [Required]
        public string SeatType {get; set;}
        [Required]
        public string Gender {get; set;}
        public int Amount {get; set;}
        
    }
}
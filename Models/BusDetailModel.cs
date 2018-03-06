using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    public class BusDetailModel:BaseModel
    {
        [Required]
        public string BusNo { get; set;}
        
        [Required]
        public int  LowerSeats { get; set;}

        [Required]
        public int  UpperSeats { get; set;}
        public string BusDescription { get; set;}
    }
}
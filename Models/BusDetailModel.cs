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
        public int  SeatingSeats { get; set;}
        [Required]
        public int  SleeperSeats { get; set;}
        public string BusDescription { get; set;}
    }
}
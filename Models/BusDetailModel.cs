using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingSystemApi.Models
{
    public class BusDetailModel:BaseModel
    {
        [Required]
        public string BusNo { get; set;}
        [Required]
        public int  SeatingSeats { get; set;}
        [Required]
        public int  SleeperSeatsUB { get; set;}
        public int  SleeperSeatsLB { get; set;}
        public string BusDescription { get; set;}

        [NotMapped]
        public List<SeatDetails> BookedSeatDetails {get; set;}
    }
}
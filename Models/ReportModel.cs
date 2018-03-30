using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookingSystemApi.Models
{
    public class ReportModel
    {
        public string Name { get; set;}
        public string Email {get; set;}
        public string Source {get; set;}
        public string Destination {get; set;}
        public string PhoneNo {get; set;}
        public string BookingNumber {get; set;}
        public string Seats {get; set;}
        public string JourneyDate {get; set;}
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;

namespace BookingSystemApi.ViewModels
{
    public class BaseViewModel
    {
        
        #region  Helper Methods Methods
        public  string GenerateTicketNumber()
        {
           var dt= DateTime.Now;
            var data= dt.Year.ToString("0000")
            +dt.Date.Month.ToString("00")
            +dt.Date.Day.ToString("00")
            +dt.TimeOfDay.Hours.ToString("00")
            +dt.TimeOfDay.Minutes.ToString("00")
            +dt.TimeOfDay.Seconds.ToString("00");
            return data;
        }
        #endregion
    }
    public class ClientMessage<T> where T:class
    {
        public bool HasError { get; set; }
        public string Message { get; set; }

        public T ClientData { get; set;}
    }
}
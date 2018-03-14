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
            var data= dt.Year.ToString("yyyy")+
            dt.Month.ToString("MM")
            +dt.Date.ToString("dd")
            +dt.Hour.ToString("hh")
            +dt.Minute.ToString("mm")
            +dt.Second.ToString("ss");
            return data;
        }
        #endregion
    }
}
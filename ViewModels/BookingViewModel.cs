using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;

namespace BookingSystemApi.ViewModels
{
    public class BookingViewModel:BaseViewModel
    {
        #region Private Property
        private IBookingRepository _bookingRepo;
        #endregion
        public BookingViewModel(IBookingRepository bookingRepo)
        {
            this._bookingRepo=bookingRepo;
        }
        public BookingViewModel()
        {
            
        }
        public string SaveBookingDetails(BookingModel model)
        {
           model.BookingNumber= base.GenerateTicketNumber();
           var data = _bookingRepo.Add(model);
           if(data.IsCompletedSuccessfully)
           {
               return "success";
           }
           else
           {
               return "Error";
           }
        }
        #region  Private Methods
        
        #endregion
    }
}
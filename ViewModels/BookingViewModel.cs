using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;
using Newtonsoft.Json;

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
        public ClientMessage<BookingModel> SaveBookingDetails(BookingModel model)
        {
           model.BookingNumber= base.GenerateTicketNumber();
           Console.WriteLine(model.BookingNumber);
           model.CreatedDate=DateTime.Now;
           model.ID=Guid.NewGuid();
           //model.BusID=Guid.NewGuid();
           var data = _bookingRepo.Add(model);
           var _clientMessage= new ClientMessage<BookingModel>();
           _clientMessage.ClientData=model;
           if(data.IsCompletedSuccessfully)
           {
               _clientMessage.HasError=true;
           }
           
           return _clientMessage;
        }
        public async Task<List<SeatDetails>> GetBookedSeats(BookingModel model)
        {
           
           var data = await _bookingRepo.GetBookedTicketDetails(model);
           var result= new List<SeatDetails>();
           foreach (var item in data)
           {
              result.AddRange(JsonConvert.DeserializeObject<List<SeatDetails>>(item));
           }  
           return result;
           
        }
        #region  Private Methods
        
        #endregion
    }
}
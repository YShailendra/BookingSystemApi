using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;
using Newtonsoft.Json;
using BookingSystemApi.Helper;
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
            var _clientMessage = new ClientMessage<BookingModel>();
            if (this.ValidateBooking(model))
            {
                model.BookingNumber = base.GenerateTicketNumber();
                Console.WriteLine(model.BookingNumber);
                model.CreatedDate = DateTime.Now;
                model.ID = Guid.NewGuid();
                var data = _bookingRepo.Add(model);

                _clientMessage.ClientData = model;
                //this.SendMailToTicketOwner(model);
                if (data.IsCompletedSuccessfully)
                {
                    _clientMessage.HasError = true;
                }
            }
            else{
                 _clientMessage.ClientData = model;
                  _clientMessage.HasError = true;
                   _clientMessage.Message = "Seat Already Booked!";
            }


            return _clientMessage;
        }
        public async Task<List<SeatDetails>> GetBookedSeats(BookingModel model)
        {

            var data = await _bookingRepo.GetBookedTicketDetails(model);
            var result = new List<SeatDetails>();
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    result.AddRange(JsonConvert.DeserializeObject<List<SeatDetails>>(item));
                }
            }

            return result;

        }
        public  ClientMessage<BookingModel> GetBookingDetails(string bookingnumber,string email)
        {
           
           //model.BusID=Guid.NewGuid();
           var data = _bookingRepo.Find(bookingnumber);
           var _clientMessage= new ClientMessage<BookingModel>();
           _clientMessage.ClientData=data.Result;
           //EmaiilHelper
           if(data.IsCompletedSuccessfully)
           {
               _clientMessage.HasError=true;
           }
           
           return   _clientMessage;
        }
        #region  Private Methods
        private void SendMailToTicketOwner(BookingModel model)
        {
            string subject= string.Format("Bus ticket confirmation");
            string message= string.Format("Ticket is booked and booking number is {0}",model.BookingNumber);
            EmailHelper.SendMail(model.Email,message,subject);
        }
        private bool ValidateBooking(BookingModel model)
        {
            bool iresult=false;
            var data = this._bookingRepo.GetBookedTicketDetails(model).Result;
             var result = new List<SeatDetails>();
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    result.AddRange(JsonConvert.DeserializeObject<List<SeatDetails>>(item));
                }
            }
            var dataExist= model.BookedSeatDetails.Except(result);
            if(dataExist.Count()==model.BookedSeatDetails.Count)
            {
                iresult=true;
            }
            return iresult;
        }
        #endregion
    }
}
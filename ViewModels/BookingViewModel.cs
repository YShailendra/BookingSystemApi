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
                var data = _bookingRepo.Add(model);
                _clientMessage.ClientData = model;
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
        
        public ClientMessage<BookingModel> CancelAndConfirmBooking(BookingModel model,int bookingSattus)
        {
            var _clientMessage = new ClientMessage<BookingModel>();
            if (model!=null)
            {
                model.Status=bookingSattus;
                model.UpdatedDate=DateTime.Now;
                var data = _bookingRepo.Update(model);
                _clientMessage.ClientData = model;
                
                if (data.IsCompletedSuccessfully)
                {
                    _clientMessage.HasError = true;
                }
            }
            else{
                 _clientMessage.ClientData = model;
                  _clientMessage.HasError = true;
                   _clientMessage.Message = "Booking data not found!";
            }
            return _clientMessage;
        }
        public async Task<List<SeatDetails>> GetBookedSeats(BookingModel model)
        {

            var data = await _bookingRepo.GetBookedTicketDetails(model);
            return data;

        }
        public  async Task<BookingModel> GetBookingDetails(string bookingnumber,string email)
        {
           var data = await _bookingRepo.GetBookedTicketByBookingNumber(bookingnumber);
           return   data;
        }
        public async Task<BookingModel> GetBookingById(Guid id)
        {
           var data = await _bookingRepo.Find(id.ToString());
           return data;
        }
        public async Task<IEnumerable<ReportModel>> GetBookingReport(DateTime? date,Guid? busid,int days=0)
        {
           var data = await _bookingRepo.GetBookingReport(date,busid,days);
           return data;
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
            var result = this._bookingRepo.GetBookedTicketDetails(model).Result;
             //var result = new List<SeatDetails>();
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
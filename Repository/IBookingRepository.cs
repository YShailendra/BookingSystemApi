using BookingSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace BookingSystemApi.Repository
{
    public interface IBookingRepository:IBaseRepository<BookingModel>
    {
        
        Task<List<SeatDetails>> GetBookedTicketDetails(BookingModel item);
        Task<BookingModel> GetBookedTicketByBookingNumber(string bookingnumber);

        Task<IEnumerable<ReportModel>> GetBookingReport(DateTime? date,Guid? busid,int days);
    }
    
}
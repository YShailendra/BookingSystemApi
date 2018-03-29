using BookingSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IBookingRepository:IBaseRepository<BookingModel>
    {
        
        Task<List<SeatDetails>> GetBookedTicketDetails(BookingModel item);
        
    }
    
}
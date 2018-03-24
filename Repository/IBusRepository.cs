using BookingSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IBusRepository:IBaseRepository<BusDetailModel>
    {
        Task<List<BusDetailModel>> GetBusByRoute(string source, string destination);
    }
}
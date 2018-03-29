using BookingSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IBusRepository:IBaseRepository<BusDetailModel>
    {
        Task<List<BusDetailModel>> GetBusByRoute(BookingModel model);

        Task<List<RouteModel>> GetRoute(string name="");

        Task<List<StationModel>> GetStation(string name="");

        Task<List<BusDetailModel>> GetBusByRouteId(string routeid);

    }
}
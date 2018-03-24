using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;

namespace BookingSystemApi.ViewModels
{
    public class BusViewModel:BaseViewModel
    {
        #region Private Property
        private IBusRepository _busRepo;
        #endregion
        public BusViewModel(IBusRepository busRepo)
        {
            this._busRepo=busRepo;
        }
        public BusViewModel()
        {
            
        }
        public string Save(BusDetailModel model)
        {
           
           
           model.CreatedDate=DateTime.Now;
           model.ID=Guid.NewGuid();
           var data = _busRepo.Add(model);
           if(data.IsCompletedSuccessfully)
           {
               return "success";
           }
           else
           {
               return "Error";
           }
        }
        public async Task<IEnumerable<BusDetailModel>> GetBusDetails(string source,string desination)
        {
            var data= await this._busRepo.GetBusByRoute(source,desination);
            return data;
        }

        public async Task<IEnumerable<StationModel>> GetStation(string name="")
        {
            var data= await this._busRepo.GetStation(name);
            return data;
        }

        public async Task<IEnumerable<RouteModel>> GetRoute(string name="")
        {
            var data= await this._busRepo.GetRoute(name);
            return data;
        }

        public async Task<IEnumerable<BusDetailModel>> GetBusByRouteId(string routeid)
        {
            var data= await this._busRepo.GetBusByRouteId(routeid);
            return data;
        }
        #region  Private Methods
        
        #endregion
    }
}
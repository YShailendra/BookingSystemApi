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
        #region  Private Methods
        
        #endregion
    }
}
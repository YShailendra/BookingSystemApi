using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingSystemApi.Models;
using BookingSystemApi.Repository;

namespace BookingSystemApi.ViewModels
{
    public class UserViewModel
    {
        #region Private Variables 
        private IUserRepository _repo;
        #endregion
        public UserViewModel(IUserRepository repo)
        {
            this._repo=repo;
        }
        UserViewModel()
        {
        }

        public UserModel RegisterUser(UserModel data)
        {
            var result =this._repo.Add(data);
            return result;
        }
    }
}
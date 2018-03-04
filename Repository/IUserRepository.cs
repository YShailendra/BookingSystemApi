using BookingSystemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IUserRepository:IBaseRepository<UserModel>
    {
        UserModel GetByEmailOrNumber(string _value);
    }
}
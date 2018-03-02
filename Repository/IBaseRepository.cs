using BookingSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T item);
        IEnumerable<T> GetAll();
        T Find(string key);
        T Remove(string Id);
        T Update(T item);
        bool CheckValidUserKey(string reqkey);
    }
}
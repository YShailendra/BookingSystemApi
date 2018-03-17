using BookingSystemApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(string key);
        Task<T> Remove(string Id);
        Task<T> Update(T item);
    }
}
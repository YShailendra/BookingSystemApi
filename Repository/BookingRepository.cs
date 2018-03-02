using BookingSystemApi.Context;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public class BookingRepository:IBookingRepository
    {
        BookingDbContext context;
        public BookingRepository(BookingDbContext context)
        {
            this.context=context;
        }
        public BookingRepository()
        {

        }
        public BookingModel Add(BookingModel item)
        {
            if(item!=null)
            {
                this.context.Booking.Add(item);
                this.context.SaveChanges();
            }
            return item;
        }
        public IEnumerable<BookingModel> GetAll()
        {
            var data=this.context.Booking.AsEnumerable();
            return data;
        }
        public BookingModel Find(string key)
        {
            var data=this.context.Booking.FirstOrDefault(w=>w.BookingNumber==key);
            return data;
        }
        public BookingModel Remove(string Id)
        {
            var data =this.Find(Id);
            if(data!=null)
            {
                this.context.Remove(data);
                this.context.SaveChanges();
            }
            return data;
        }
        public BookingModel Update(BookingModel item)
        {
            if(item!=null)
            {
              this.context.Entry(item).State=EntityState.Modified;
              this.context.SaveChanges();
            }
            return item;
        }
        public bool CheckValidUserKey(string reqkey)
        {
            //TO:DO
            return false;
        }
    }
}
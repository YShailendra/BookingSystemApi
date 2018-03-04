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
        public async Task<BookingModel> Add(BookingModel item)
        {
            if(item!=null)
            {
                await this.context.Booking.AddAsync(item);
                await this.context.SaveChangesAsync();
            }
            return item;
        }
        public async Task<IEnumerable<BookingModel>> GetAll()
        {
            var data= await this.context.Booking.ToListAsync();
            return data;
        }
        public async Task<BookingModel> Find(string key)
        {
            var data=await this.context.Booking.Where(w=>w.BookingNumber==key).SingleOrDefaultAsync();
            return data;
        }
        public async Task<BookingModel> Remove(string Id)
        {
            var data =this.Find(Id);
            if(data!=null)
            {
               this.context.Remove(data);
               await this.context.SaveChangesAsync();
            }
            return await data;
        }
        public async Task<BookingModel> Update(BookingModel item)
        {
            if(item!=null)
            {
              this.context.Entry(item).State=EntityState.Modified;
              await this.context.SaveChangesAsync();
            }
            return item;
        }
        
    }
}
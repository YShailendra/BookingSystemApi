using BookingSystemApi.Context;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
            try
            {
                if (item != null)
                {
                    await this.context.Booking.AddAsync(item);
                    await this.context.SaveChangesAsync();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.InnerException);
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
            var data=await this.context.Booking.Include(i=>i.BookedSeatDetails).Where(w=>w.ID==Guid.Parse(key)).FirstOrDefaultAsync();
            return data;
        }
        public async Task<BookingModel> GetBookedTicketByBookingNumber(string bookingnumber)
        {
            Console.WriteLine("booking number ="+bookingnumber);
            var data=await this.context.Booking.Include(i=>i.BookedSeatDetails).Where(w=>w.BookingNumber==bookingnumber).SingleOrDefaultAsync();
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
        public async Task<List<SeatDetails>> GetBookedTicketDetails(BookingModel item)
        {
            var data = await this.context.SeatDetails.Where(w=>w.Booking.JourneyDate.Date==item.JourneyDate.Date && w.Booking.BusID==item.BusID).AsQueryable().ToListAsync();
            return data;
        }
        public async Task<IEnumerable<ReportModel>> GetBookingReport(DateTime? date,Guid? busid,int days)
        {
             var data= await this.context.Booking.Include(i=>i.BookedSeatDetails).Select(s=> new ReportModel{
                 Name=s.Name,
                 Email=s.Email,
                 PhoneNo=s.PhoneNo,
                 BookingNumber=s.BookingNumber,
                 Source=s.Source,
                 Destination=s.Destination,
                 Seats= string.Join(",", s.BookedSeatDetails.Select(ss=>ss.SeatId).ToArray()),
                 JourneyDate=s.JourneyDate.ToLongDateString(),
             }).ToListAsync();
            return data;
        }
        
    }
}
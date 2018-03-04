
using System;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingSystemApi.Context
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            :base(options) { }
        public BookingDbContext(){ }
        public DbSet<BookingModel> Booking { get; set; }
        public DbSet<UserModel> User { get; set; }
        internal object AsEnumerable()
        {
            throw new NotImplementedException();
        }
    }
}
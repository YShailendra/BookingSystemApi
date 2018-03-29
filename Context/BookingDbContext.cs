
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
        public DbSet<BusDetailModel> BusDetail { get; set; }
        public DbSet<RouteModel> Route { get; set; }
        public DbSet<StationModel> Station { get; set; }
        public DbSet<RouteStationModel> RouteStation { get; set; }
        public DbSet<BusRouteModel> BusRoute{ get; set; }
        public DbSet<SeatDetails> SeatDetails {get; set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
        
         builder.Entity<UserModel>(entity => {
                    entity.HasIndex(e => e.Email).IsUnique();
                    entity.HasIndex(e=>e.PhoneNo).IsUnique();
                });       
        }
        
    }
}
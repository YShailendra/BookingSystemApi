using BookingSystemApi.Context;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public class BaseRepository<T> where T:class
    {
        
        
        public void SaveChanges(BookingDbContext context)
        {   
            context.SaveChangesAsync();
        }
        
    }
}
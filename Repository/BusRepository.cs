using BookingSystemApi.Context;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public class BusRepository:IBusRepository
    {
        private BookingDbContext context;

        public BusRepository(BookingDbContext context)
        {
            this.context = context;
        }

        public BusRepository()
        {

        }
        public async Task<BusDetailModel> Add(BusDetailModel item)
        {
            await this.context.BusDetail.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<BusDetailModel>>GetAll()
        {
            var data= await this.context.BusDetail.ToListAsync();
            return data;
        }
        public async Task<BusDetailModel> Find(string Id)
        {
            return await this.context.BusDetail.Where(w=>w.ID==Guid.Parse(Id)).SingleOrDefaultAsync();
        }
        
        public async Task<BusDetailModel> Remove(string Id)
        {
            var itemToRemove = await context.BusDetail.SingleOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.BusDetail.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<BusDetailModel> Update(BusDetailModel item)
        {
            if(item!=null)
            {
                this.context.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                await this.context.SaveChangesAsync();
            }
            return item;
        }
        
    }
}
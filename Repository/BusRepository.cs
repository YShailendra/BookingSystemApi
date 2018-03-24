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
        public async Task<List<BusDetailModel>>GetBusByRoute(string source, string destinaton)
        {
            var data= await this.context.Station.Where(w=>w.StationName==source||w.StationName==destinaton)
            .Join(this.context.RouteStation,st=>st.ID,rt=>rt.StationID, (st,rt)=>new {st,rt})
            .Join(this.context.BusRoute,sr=>sr.rt.RouteID,br=>br.RouteID,(sr,br)=>new {sr,br}).
             Join(this.context.BusDetail,bsr=>bsr.br.BusID,bus=>bus.ID,(bsr,bus)=>new { bsr,bus }).Select(s=> new BusDetailModel{
             BusDescription=s.bus.BusDescription,
             BusNo=s.bus.BusNo,
             ID=s.bus.ID
            }).ToListAsync();
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
        public async Task<List<StationModel>> GetStation(string name="")
        {
            return await this.context.Station.AsQueryable().ToListAsync();
        }
        //
        public async Task<List<RouteModel>> GetRoute(string name="")
        {

            return await this.context.Route.AsQueryable().ToListAsync();;
        }
        public async Task<List<BusDetailModel>> GetBusByRouteId(string routeid)
        {
            var data=this.context.BusRoute.Join(this.context.BusDetail,br=>br.BusID,bs=>bs.ID,(br,bs)=>new { br,bs}).Select(s=> new BusDetailModel{
            BusDescription=s.bs.BusDescription,
            BusNo=s.bs.BusNo,
            ID=s.bs.ID
            }).ToListAsync();
            return await data;
        }
    }
}
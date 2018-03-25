using BookingSystemApi.Context;
using BookingSystemApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystemApi.Repository
{
    public class UserRepository:IUserRepository
    {
        private BookingDbContext context;

        public UserRepository(BookingDbContext context)
        {
            this.context = context;
        }

        public UserRepository()
        {

        }
        public async Task<UserModel> Add(UserModel item)
        {
            await this.context.User.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<UserModel>>GetAll()
        {
            var data= await this.context.User.ToListAsync();
            return data;
        }
        public async Task<UserModel> Find(string Id)
        {
            return await this.context.User.Where(w=>w.ID==Guid.Parse(Id)).SingleOrDefaultAsync();
        }
        public async Task<UserModel> GetByEmailOrNumber(string _value)
        {
            return await this.context.User.Where(w=>w.Username==_value||w.PhoneNo==_value||w.Email==_value).FirstOrDefaultAsync();
        }
        public async Task<UserModel> Remove(string Id)
        {
            var itemToRemove = await context.User.SingleOrDefaultAsync(r => r.ID == Guid.Parse(Id));
            if (itemToRemove != null)
            {
                context.User.Remove(itemToRemove);
                await context.SaveChangesAsync();
            }

            return itemToRemove;
        }
        public async Task<UserModel> Update(UserModel item)
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
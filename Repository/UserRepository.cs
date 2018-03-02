using BookingSystemApi.Context;
using BookingSystemApi.Models;
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
        public UserModel Add(UserModel item)
        {
            this.context.User.Add(item);
            this.context.SaveChanges();
            return item;
        }
        public IEnumerable<UserModel> GetAll()
        {
            var data= this.context.User.AsEnumerable();
            return data;
        }
        public UserModel Find(string Id)
        {
            return this.context.User.Find(Guid.Parse(Id));
        }
        public UserModel Remove(string Id)
        {
            var data = this.context.User.Find(Guid.Parse(Id));
            if (data != null)
            {
                this.context.User.Remove(data);
                this.context.SaveChanges();
            }

            return data;
        }
        public UserModel Update(UserModel item)
        {
            if(item!=null)
            {
                this.context.Entry(item).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Models
{
    public class UserModel:BaseModel
    {
        public string Username { get; set;}
        public string Password {get; set;}
        public string Email {get; set;}
        public string PhoneNo {get; set;}
        public string IsAdmin {get; set;}
        public string City {get; set;}
        public string Addr {get; set;}
    }
}
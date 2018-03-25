using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Models
{
    public class LoginModel
    {
        public string Username { get; set;}
        public string Password {get; set;}
        public bool IsAdmin {get;set;}
        public string Token {get;set;}


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystemApi.Models
{
    public class UserModel:BaseModel
    {
        public string Username { get; set;}
        [Required]
        public string Password {get; set;}
        
        [Required]
        public string Email {get; set;}
        [Required]
        [MinLength(10)]
        public string PhoneNo {get; set;}
        [Required]
        public string Name { get; set;}
        public Boolean? IsAdmin {get; set;}
        public string City {get; set;}
        public string Addr {get; set;}
    }
}
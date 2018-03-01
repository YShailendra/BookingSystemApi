using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingSystemApi.Models; 
using BookingSystemApi.Helper;
namespace BookingSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginModel inputModel)
        {
            if (inputModel.Username != "raj" && inputModel.Password != "password")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("Test-secret-key-1234"))
                                .AddSubject("Raj Kumar")
                                .AddIssuer("Test.Security.Bearer")
                                .AddAudience("Test.Security.Bearer")
                                .AddClaim("EmployeeNumber", "6109")
                                .AddExpiry(5)
                                .Build();

            //return Ok(token);
            return Ok(token.Value); 
        }
    }
}
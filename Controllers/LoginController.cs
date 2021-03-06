using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingSystemApi.Models;
using BookingSystemApi.Helper;
using BookingSystemApi.Repository;
namespace BookingSystemApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        #region Private Variable
        public IUserRepository userRepo { get; set; }
        #endregion
        public LoginController(IUserRepository iUserRepository)
        {
            this.userRepo = iUserRepository;
        }

        [HttpPost]
        public IActionResult Create([FromBody]LoginModel inputModel)
        {
            if (!string.IsNullOrEmpty(inputModel.Username) &&
            !string.IsNullOrEmpty(inputModel.Password))
            {
                var user = this.userRepo.GetByEmailOrNumber(inputModel.Username);
                if (user != null)
                {
                    if (user.Password == inputModel.Password)
                    {
                        var token = new JwtTokenBuilder()
                                                        .AddSecurityKey(JwtSecurityKey.Create(user.ID.ToString()))
                                                        .AddSubject(user.Email)
                                                        .AddIssuer("Security.Bearer")
                                                        .AddAudience("Security.Bearer")
                                                        .AddClaim("IsAdmin", user.IsAdmin)
                                                        .AddExpiry(5)
                                                        .Build();
                        return Ok(token);
                    }
                    else
                    {
                        return Ok("Wrong Password");
                    }
                }
                else
                {
                    return Ok("Not registered");
                }
            }
            else
            {
                return Ok("Email and password blank");
            }
        }
    }
}
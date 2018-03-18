using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BookingSystemApi.Helper;
using BookingSystemApi.Context;
using Microsoft.EntityFrameworkCore;
using BookingSystemApi.Repository;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace BookingSystemApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //allow cors 
            services.AddCors();
        //    services.AddCors(options =>
        //   {
        //       options.AddPolicy("AllowAllOrigins",
        //        builder =>
        //        {
        //            builder.AllowAnyOrigin().AllowAnyHeader();
        //        });
        //   });
            // services.AddCors(options =>
            // {
            //  options.AddPolicy("AllowSpecificOrigin",
            //  builder => builder.WithOrigins("http://localhost:4200"));
            // });
            // services.Configure<MvcOptions>(options =>
            // {
            //     options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAllOrigins"));
            // });
            services.AddDbContext<BookingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //using Dependency Injection
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IBookingRepository, BookingRepository>();
            services.AddSingleton<IBusRepository, BusRepository>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,

                                 ValidIssuer = "Test.Security.Bearer",
                                 ValidAudience = "Test.Security.Bearer",
                                 IssuerSigningKey = JwtSecurityKey.Create("Test-secret-key-1234")
                             };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };

                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin",
                    policy => policy.RequireClaim("EmployeeNumber"));
                options.AddPolicy("Agent",
                    policy => policy.RequireClaim("EmployeeNumber"));
                options.AddPolicy("Founder",
                    policy => policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
            });
            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            //allow cors 
            //services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
            app.UseMvc();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Mapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;


namespace eShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<ICartManager, CartManager>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<ICartBusinessLogic, CartBusinessLogic>();
            services.AddScoped<IUserBusinessLogic, UserBusinessLogic>();
            services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddScoped<IOrderBusinessLogic, OrderBusinessLogic>();





            // services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(MapperProfiles));

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

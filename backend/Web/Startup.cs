using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using StackExchange.Profiling;

namespace Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMiniProfiler().AddEntityFramework();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });


            services.AddMemoryCache();

            services.AddScoped<MappingService, MappingService>();

            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IClothingService, ClothingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICostumerService, CostumerService>();
            services.AddScoped<IOrderLineService, OrderLineService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IClothingRepository, ClothingRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICostumerRepository, CostumerRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddDbContext<ShopContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("eShopConnection"))
            .EnableSensitiveDataLogging(true));

   

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/Clothing/Index", "");
                    options.Conventions.AddPageRoute("/Clothing/Index", "Index");
                    options.Conventions.AddPageRoute("/Checkout/CheckoutIndex", "Checkout");
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiniProfiler();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCookiePolicy();

    

            app.UseMvc();
        }
    }
}

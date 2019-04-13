using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string CorsPolicyOrigins = "_corsPolicyOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyOrigins,
                builder =>
                {
                    builder.SetIsOriginAllowed(url => url.Contains("localhost"))
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
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


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "eShop WebApi",
                    Description = "The WebApi for my eShop project",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Jimmy Elkjer",
                        Email = "Unknown",
                        Url = "Unknown"
                    },
                });
            });
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eShop WebApi V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(CorsPolicyOrigins);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}

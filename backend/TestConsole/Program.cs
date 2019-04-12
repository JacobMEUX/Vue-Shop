using DataLayer;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            XmlConfigurator.Configure(LogManager.GetRepository(Assembly.GetEntryAssembly()), new FileInfo("log4net.config"));

            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<MappingService, MappingService>()
                .AddScoped<ICrudService<BrandDTO>, BrandService>()
                .AddScoped<ICrudRepository<Brand>, BrandRepository>()
                .AddDbContext<ShopContext>()
                .AddLogging(logging => 
                logging.AddLog4Net()
                .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider();


            ICrudService<BrandDTO> brandService = serviceProvider.GetService<ICrudService<BrandDTO>>();
            var liste = brandService.GetAll().Result;

            foreach (BrandDTO item in liste)
            {
                Console.WriteLine($"ID: {item.BrandId} \tName: {item.Name}");
            }

            Console.WriteLine("Tryk på en knap (ANY)");
            Console.ReadKey();
        }



    }

}


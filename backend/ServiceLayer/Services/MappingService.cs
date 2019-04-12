using DataLayer.Entities;
using DataLayer.Entities.Enums;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Services
{
    /// <summary>
    /// The MappingService. Used for Automapper so only 1 mapper is needed.
    /// </summary>
    public class MappingService
    {
        public readonly AutoMapper.IMapper _mapper;
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingService"/> class.
        /// </summary>
        public MappingService()
        {
            AutoMapper.MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;

                // Brand
                cfg.CreateMap<Brand, BrandDTO>();
                cfg.CreateMap<BrandDTO, Brand>();

                // Category
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<CategoryDTO, Category>();

                // Order
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();

                // Clothing
                cfg.CreateMap<Clothing, ClothingDTO>();
                cfg.CreateMap<ClothingDTO, Clothing>();

                // Costumer
                cfg.CreateMap<Costumer, CostumerDTO>();
                cfg.CreateMap<CostumerDTO, Costumer>();

                // OrderLine
                cfg.CreateMap<OrderLine, OrderLineDTO>();
                cfg.CreateMap<OrderLineDTO, OrderLine>();

                // Image
                cfg.CreateMap<Image, ImageDTO>();
                cfg.CreateMap<ImageDTO, Image>();

                // SortFilterSearchOptions
                cfg.CreateMap<SortFilterSearchOptions, SortFilterSearchOptionsDTO>();
                cfg.CreateMap<SortFilterSearchOptionsDTO, SortFilterSearchOptions>();

                // Colors
                cfg.CreateMap<Colors, ColorsDTO>();
                cfg.CreateMap<ColorsDTO, Colors>();

                // PaymentMethods
                cfg.CreateMap<PaymentMethods, PaymentMethodsDTO>();
                cfg.CreateMap<PaymentMethodsDTO, PaymentMethods>();

                // Sizes
                cfg.CreateMap<Sizes, SizesDTO>();
                cfg.CreateMap<SizesDTO, Sizes>();

                // SortOrder
                cfg.CreateMap<SortOrder, SortOrderDTO>();
                cfg.CreateMap<SortOrderDTO, SortOrder>();


            });

                _mapper = mapperConfig.CreateMapper();


        }
    }
}

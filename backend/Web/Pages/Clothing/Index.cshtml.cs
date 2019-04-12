using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.Enums;
using ServiceLayer.Interfaces;
using Web.Areas.Identity.Data;
using Web.Extentions;

namespace Web.Pages.Clothing
{
    public class IndexModel : PageModel
    {
        private readonly IClothingService _clothingService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _cache;
        


        public IndexModel(IClothingService clothingService, IBrandService brandService, ICategoryService categoryService, IMemoryCache cache)
        {
            _cache = cache;
            _clothingService = clothingService;
            _clothingService = clothingService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        public List<ClothingDTO> Clothing { get; set; }
        public List<OrderLineDTO> OrderLineDTOs { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }
        [TempData]
        public string Message { get; set; }

        #region Paging
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 6;
        [BindProperty(SupportsGet = true)]
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        #endregion

        #region Filtering
        [BindProperty(SupportsGet = true)]
        public int? SelectedBrandId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? SelectedCategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public ColorsDTO? SelectedColor { get; set; }
        [BindProperty(SupportsGet = true)]
        public SizesDTO? SelectedSize { get; set; }
        [BindProperty(SupportsGet = true)]
        public SortOrderDTO? SelectedSortOrder { get; set; } = SortOrderDTO.BrandASC;
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        #endregion

        public async Task OnGetAsync()
        {

            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }

            SortFilterSearchOptionsDTO options = new SortFilterSearchOptionsDTO()
            {
                BrandId = SelectedBrandId,
                CategoryId = SelectedCategoryId,
                Color = SelectedColor,
                Size = SelectedSize,
                Search = Search,
                CurrentPage = CurrentPage,
                PageSize = PageSize,
                SortOrder = SelectedSortOrder
            };

            Clothing = await _clothingService.GetClothing(options);
            Count = await _clothingService.GetCount(options);


            Brands = await _cache.GetOrCreate("Brands", async entry =>
            {
                entry.SlidingExpiration = new TimeSpan(0, 0, 20);
                return new SelectList(await _brandService.GetAll(), nameof(BrandDTO.BrandId), nameof(BrandDTO.Name));
            });

            Categories = await _cache.GetOrCreate("Categories", async entry =>
            {
                entry.SlidingExpiration = new TimeSpan(0, 0, 20);
                return new SelectList(await _categoryService.GetAll(), nameof(CategoryDTO.CategoryId), nameof(CategoryDTO.Name));
            });


            OrderLineDTOs = HttpContext.Session.GetShoppingCart("Kurven");

        }

        public async Task<IActionResult> OnPostAddAsync(int clothId)
        {

            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Kurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Kurven");
                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO updateMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(updateMe);
                    updateMe.Amount += 1;
                    shoppingKurv.Add(updateMe);
                    HttpContext.Session.SetShoppingCart("Kurven", shoppingKurv);
                    TempData["Message"] = $"Successfully increased the amount of {updateMe.Clothing.Title} in the shopcart!";
                }
                else
                {
                    OrderLineDTO orderLine = new OrderLineDTO()
                    {
                        FKClothingId = (int)clothId,
                        Amount = 1,
                        Clothing = await _clothingService.GetByID(clothId)

                    };
                    shoppingKurv.Add(orderLine);
                    TempData["Message"] = "Successfully added item to shopcart!";
                }

                HttpContext.Session.SetShoppingCart("Kurven", shoppingKurv);

            }
            return RedirectToPage("./Index", null);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int clothId)
        {
            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Kurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Kurven");

                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO removeMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(removeMe);
                    HttpContext.Session.SetShoppingCart("Kurven", shoppingKurv);
                    TempData["Message"] = "Successfully removed item from shopcart!";
                }

            }
            return RedirectToPage("./Index", null);

        }

        public async Task<IActionResult> OnPostAddOneAsync(int clothId)
        {
            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Kurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Kurven");

                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO updateMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(updateMe);
                    updateMe.Amount += 1;
                    shoppingKurv.Add(updateMe);
                    HttpContext.Session.SetShoppingCart("Kurven", shoppingKurv);
                    TempData["Message"] = $"Successfully increased the amount of {updateMe.Clothing.Title} in the shopcart!";
                }


            }
            return RedirectToPage("./Index", null);

        }

        public async Task<IActionResult> OnPostRemoveOneAsync(int clothId)
        {
            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Kurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Kurven");

                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO updateMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(updateMe);
                    if (updateMe.Amount > 1)
                    {
                        updateMe.Amount -= 1;
                        shoppingKurv.Add(updateMe);
                    }

                    HttpContext.Session.SetShoppingCart("Kurven", shoppingKurv);
                    TempData["Message"] = $"Successfully reduced the amount of {updateMe.Clothing.Title} in the shopcart!";
                }


            }
            return RedirectToPage("./Index", null);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using Web.Extentions;

namespace Web.Pages.ShoppingCart
{
    public class ShoppingCartCrudModel : PageModel
    {
        public IClothingService _clothingService;
        public ShoppingCartCrudModel(IClothingService clothingService)
        {
            _clothingService = clothingService;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAddAsync(int clothId)
        {

            if (HttpContext.Session.GetShoppingCart("Spurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Spurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Spurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Spurven");
                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    ModelState.AddModelError("OrderLineDTOs", "NEJ!");
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
                }

                HttpContext.Session.SetShoppingCart("Spurven", shoppingKurv);
            }
            return RedirectToPage("./Index", null);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int clothId)
        {
            if (HttpContext.Session.GetShoppingCart("Spurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Spurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Spurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Spurven");

                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO removeMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(removeMe);
                    HttpContext.Session.SetShoppingCart("Spurven", shoppingKurv);
                }

            }
            return RedirectToPage("./Index", null);

        }

        public async Task<IActionResult> OnPostSingleAsync(int clothId, int amount)
        {
            if (HttpContext.Session.GetShoppingCart("Spurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Spurven", new List<OrderLineDTO>());
            }
            else if (HttpContext.Session.Get<List<OrderLineDTO>>("Spurven") != null)
            {
                List<OrderLineDTO> shoppingKurv = HttpContext.Session.Get<List<OrderLineDTO>>("Spurven");

                if (shoppingKurv.Any(o => o.FKClothingId == clothId))
                {
                    OrderLineDTO updateMe = shoppingKurv.First(o => o.FKClothingId == clothId);

                    shoppingKurv.Remove(updateMe);
                    updateMe.Amount = amount;
                    shoppingKurv.Add(updateMe);
                    TempData["Message"] = "Successfully deleted item from shopcart!";
                    HttpContext.Session.SetShoppingCart("Spurven", shoppingKurv);
                }

            }
            return RedirectToPage("./Index", null);

        }

        public async Task<IActionResult> OnPostSaveAsync(string test)
        {
            return RedirectToPage("./Index", null);
            //if (HttpContext.Session.GetShoppingCart("Spurven") == null)
            //{
            //    HttpContext.Session.SetShoppingCart("Spurven", new List<OrderLineDTO>());
            //}
            //else if (HttpContext.Session.Get<List<OrderLineDTO>>("test") != null)
            //{
            //    OrderLineDTO orderLine = new OrderLineDTO()
            //    {
            //        FKClothingId = (int)clothId,
            //        Amount = 1

            //    };
            //    HttpContext.Session.Get<List<OrderLineDTO>>("test").Add(orderLine);
            //}

            #region OldCode

            /*
            //if (int.TryParse(Request.Cookies["Jimmys Småkager"], out int res))
            //{

            //    foreach (OrderLineDTO newOrderLine in newOrderLines)
            //    {
            //        await _orderLineService.Update(newOrderLine);
            //        TempData["Message"] = "Successfully saved the changes for the shopcart!";


            //    }
            //}
            return RedirectToPage("./Index", null);
            */
            #endregion
        }
    }
}
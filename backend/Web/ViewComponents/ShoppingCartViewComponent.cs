using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Extentions;

namespace Web.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public List<OrderLineDTO> OrderLines { get; set; }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            OrderLines = (HttpContext.Session.GetShoppingCart("Kurven") != null) ? HttpContext.Session.Get<List<OrderLineDTO>>("Kurven") : new List<OrderLineDTO>();
            TempData["TotalPrice"] = OrderLines.Sum(o => o.Amount * o.Clothing.Price);
            return View(OrderLines);
        }
    }
}

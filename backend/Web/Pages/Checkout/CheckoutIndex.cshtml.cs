using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using Web.Areas.Identity.Data;
using Web.Extentions;

namespace Web.Pages.Checkout
{
    public class CheckoutIndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderLineService _orderLineService;
        private readonly IClothingService _clothingService;
        private readonly IEmailSender _emailSender;

        [BindProperty(SupportsGet = true)]
        public List<OrderLineDTO> OrderLineDTOs { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }
        [BindProperty(SupportsGet = true)]
        public string UserEmail { get; set; }


        [TempData]
        public string Message { get; set; }

        public CheckoutIndexModel(IOrderService orderService, IOrderLineService orderLineService, IClothingService clothingService, IEmailSender emailSender)
        {
            _orderService = orderService;
            _orderLineService = orderLineService;
            _clothingService = clothingService;
            _emailSender = emailSender;
        }

        public async Task OnGetAsync()
        {
            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }


            OrderLineDTOs = HttpContext.Session.GetShoppingCart("Kurven");

            //TODO: Fiz this
        }

        public async Task<IActionResult> OnPostBuyAsync()
        {
            if (HttpContext.Session.GetShoppingCart("Kurven") == null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());
            }


            OrderLineDTOs = HttpContext.Session.GetShoppingCart("Kurven");

            OrderDTO orderDTO = new OrderDTO()
            {
                Date = DateTime.Now,
                FKCostumerId = UserId,
            };

            int? createdOrderId = await _orderService.CreateNewOrder(orderDTO);

            if (createdOrderId != null)
            {
                HttpContext.Session.SetShoppingCart("Kurven", new List<OrderLineDTO>());

                TempData["Message"] = "Tak for dit køb! Du vil modtage en kvittering over E-Mail!";

                string emailMessage = $"You have on {DateTime.Now.ToString("dddd, dd MMMM yyyy")} at {DateTime.Now.ToShortTimeString()} successfully purchased the following items:";

                foreach (OrderLineDTO orderLineDTO in OrderLineDTOs)
                {
                    orderLineDTO.FKOrderId = (int)createdOrderId;
                    orderLineDTO.Total = orderLineDTO.Amount * orderLineDTO.Clothing.Price;

                    OrderLineDTO emptyOrderline = new OrderLineDTO()
                    {
                        Amount = orderLineDTO.Amount,
                        FKClothingId = orderLineDTO.FKClothingId,
                        FKOrderId = orderLineDTO.FKOrderId,
                        Total = orderLineDTO.Total
                    };

                    await _orderLineService.Create(emptyOrderline);

                    emailMessage += $"\n{orderLineDTO.Amount}x {orderLineDTO.Clothing.Title} - Price: {string.Format("{0:C}", orderLineDTO.Total)}";
                }
                emailMessage += $"\n\n {string.Format("{0:C}", OrderLineDTOs.Sum(o => o.Amount * o.Clothing.Price))}";

                await _emailSender.SendEmailAsync(UserEmail, "Thank you for your purchase", emailMessage);
            }
            else
            {
                TempData["Message"] = "Der skete en fejl, prøv igen eller kontakt os hvis fejlen sker igen!";
            }
            return RedirectToPage("../Clothing/Index");
        }

    }
}
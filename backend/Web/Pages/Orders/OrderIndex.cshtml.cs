using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;
using Web.Areas.Identity.Data;
using Web.Extentions;

namespace Web.Pages.Orders
{
    public class OrderIndexModel : PageModel
    {

        private readonly IOrderService _orderService;

        private readonly UserManager<WebIdentityUser> _userManager;
        public OrderIndexModel(IOrderService orderService, UserManager<WebIdentityUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }
        //[BindProperty(SupportsGet = true)]
        public List<OrderDTO> Orders { get; set; }
        public async Task OnGetAsync()
        {
            string userId = _userManager.ConvertToWebIdentityUser(User).Id;
            Orders = await _orderService.GetOrderByCostumerId(userId);

        }
    }
}
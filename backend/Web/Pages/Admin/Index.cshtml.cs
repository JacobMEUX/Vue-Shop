using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.DTOs;
using ServiceLayer.Interfaces;

namespace Web.Pages.Admin
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly IClothingService _clothingService;
        public IndexModel(IClothingService clothingService)
        {
            _clothingService = clothingService;   
        }
        public List<ClothingDTO> Clothing { get; set; }

        public async Task OnGetAsync()
        {
            Clothing = await _clothingService.GetAll();
        }
    }
}
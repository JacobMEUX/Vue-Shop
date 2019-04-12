using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.Enums;
using ServiceLayer.Interfaces;

namespace Web.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IClothingService _clothingService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;


        public CreateModel(IClothingService clothingService, IBrandService brandService, ICategoryService categoryService)
        {
            _clothingService = clothingService;
            _brandService = brandService;
            _categoryService = categoryService;
        }
        [BindProperty]
        public ClothingDTO Clothing { get; set; }
        public SelectList Brands { get; set; }
        public SelectList Categories { get; set; }

        #region Filtering
        [BindProperty(SupportsGet = true)]
        public int? SelectedBrandId { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? SelectedCategoryId { get; set; }
        [BindProperty(SupportsGet = true)]
        public ColorsDTO? SelectedColor { get; set; }
        [BindProperty(SupportsGet = true)]
        public SizesDTO? SelectedSize { get; set; }


        #endregion

        public async Task OnGetAsync()
        {

            Brands = new SelectList(await _brandService.GetAll(), nameof(BrandDTO.BrandId), nameof(BrandDTO.Name));

            Categories = new SelectList(await _categoryService.GetAll(), nameof(CategoryDTO.CategoryId), nameof(CategoryDTO.Name));

        }



        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Clothing.FKImageId = 5;
            await _clothingService.Create(Clothing);

            return RedirectToPage("./Index");
        }
    }
}
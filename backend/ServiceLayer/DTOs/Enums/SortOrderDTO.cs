using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs.Enums
{
    public enum SortOrderDTO
    {
        [Display(Name = "Laveste pris ")]
        PriceASC = 1,
        [Display(Name = "Højeste pris")]
        PriceDSC,
        [Display(Name = "Farve stigende")]
        ColorASC,
        [Display(Name = "Farve faldende")]
        ColorDSC,
        [Display(Name = "Brand stigende")]
        BrandASC,
        [Display(Name = "Brand faldende")]
        BrandDSC,
        [Display(Name = "Kategori stigende")]
        CategoryASC,
        [Display(Name = "Kategori faldende")]
        CategoryDSC,
        [Display(Name = "Størrelse stigende")]
        SizeASC,
        [Display(Name = "Størrelse faldende")]
        SizeDSC
    }
}

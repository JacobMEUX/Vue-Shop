using ServiceLayer.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs
{
    public class ClothingDTO
    {
        [Required]
        public int ClothingId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public SizesDTO Size { get; set; }
        public ColorsDTO Color { get; set; }
        public int FKBrandId { get; set; }
        public int FKCategoryId { get; set; }
        public int FKImageId { get; set; }
        public CategoryDTO Category { get; set; }
        public BrandDTO Brand { get; set; }
        public ImageDTO Image { get; set; }
    }
}

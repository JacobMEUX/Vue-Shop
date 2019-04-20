using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Clothing
    {
        [Key]
        public int ClothingId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public Sizes Size { get; set; }
        public Colors Color { get; set; }
        [Required]
        public int FKBrandId { get; set; }
        [Required]
        public int FKCategoryId { get; set; }
        public int FKImageId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public Image Image { get; set; }
        public List<OrderLine> OrderLines { get; set; }

        #region Old
        /*
 https://dbdiagram.io/d
Table Product {
ProductId int PK
Title string
Description string
Price decimal
Rating int
DeveloperId int
Company Company
ProductTags list<ProductTags>
}

Table Tag {
TagId int PK
Name string
ProductTags list<ProductTags>
}

Table ProductTag {
ProductId int PK
TagId int PK
Product Product
Tag Tag
}

Table Company{
CompanyId int PK

}

Ref: "Product"."ProductId" < "ProductTag"."ProductId"

Ref: "Tag"."TagId" < "ProductTag"."TagId"

Ref: "Product"."Company" < "Company"."CompanyId"


public class Product
{
    [Key]
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public string Name { get; set; }


} */
        #endregion


    }
}

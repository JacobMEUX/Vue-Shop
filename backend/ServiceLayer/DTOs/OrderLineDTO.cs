using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs
{
    public class OrderLineDTO
    {
        public int FKClothingId { get; set; }
        public int FKOrderId { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public ClothingDTO Clothing { get; set; }
        public OrderDTO Order { get; set; }

    }
}

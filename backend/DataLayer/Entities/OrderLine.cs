using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class OrderLine
    {
        [Required]
        public int FKClothingId { get; set; }
        [Required]
        public int FKOrderId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Total { get; set; }
        public Clothing Clothing { get; set; }
        public Order Order { get; set; }

    }
}

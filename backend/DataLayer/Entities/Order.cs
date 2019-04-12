using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string FKCostumerId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Costumer Costumer { get; set; }
        public List<OrderLine> OrderLines { get; set; }

    }
}

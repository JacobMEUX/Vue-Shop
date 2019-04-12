using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string FKCostumerId { get; set; }
        public DateTime Date { get; set; }
        public CostumerDTO Costumer { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; }
    }
}

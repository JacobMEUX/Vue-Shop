using DataLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entities
{
    public class Costumer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CostumerId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public List<Order> Orders { get; set; }
        [Required]
        public PaymentMethods PaymentMethod { get; set; }
    }
}

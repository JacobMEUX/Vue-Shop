using ServiceLayer.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs
{
    public class CostumerDTO
    {
        [Required]
        public string CostumerId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public PaymentMethodsDTO PaymentMethod { get; set; }

    }
}

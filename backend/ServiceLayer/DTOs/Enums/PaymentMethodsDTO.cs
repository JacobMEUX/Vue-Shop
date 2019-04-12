using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.DTOs.Enums
{
    public enum PaymentMethodsDTO
    {
        Visa = 1,
        MasterCard,
        Mobilepay,
        Paypal,
        [Display(Name = "Bank Transfer ")]
        BankTransfer
    }
}

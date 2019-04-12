using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Enums
{
    //public class PaymentMethod
    //{
    //    public int PaymentMethodId { get; set; }
    //    public string Name { get; set; }
    //    public List<User> Users { get; set; }
    //}

    public enum PaymentMethods
    {
        Visa = 1,
        MasterCard,
        Mobilepay,
        Paypal,
        BankTransfer
    }
}

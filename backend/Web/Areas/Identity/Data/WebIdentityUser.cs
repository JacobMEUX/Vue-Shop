using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.DTOs;
using ServiceLayer.DTOs.Enums;

namespace Web.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebIdentityUser class
    public class WebIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public PaymentMethodsDTO PaymentMethod { get; set; }
    }
}


using Microsoft.AspNetCore.Identity;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Areas.Identity.Data;

namespace Web.Extentions
{
    public static class WebIdentityUserExtentions
    {
        public static CostumerDTO ConvertToCostumerDTO(this WebIdentityUser WebUser)
        {
            CostumerDTO costumerDTO = new CostumerDTO()
            {
                CostumerId = WebUser.Id,
                Address = WebUser.Address,
                Email = WebUser.Email,
                Name = WebUser.Name,
                PaymentMethod = WebUser.PaymentMethod
            };

            return costumerDTO;
        }

        public static WebIdentityUser ConvertToWebIdentityUser(this UserManager<WebIdentityUser> userManager, System.Security.Claims.ClaimsPrincipal user)
        {
            return userManager.Users.Single(o => o.Id == userManager.GetUserId(user));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Roles
{
    public class CreateModel : PageModel
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }


        
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostCreateAsync(string Name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(Name));
                if (result.Succeeded)
                    return RedirectToPage("../Roles/Index");
                else
                    Errors(result);
            }
            return RedirectToPage("../Roles/Create");
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
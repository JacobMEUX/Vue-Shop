using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Areas.Identity.Data;
using Web.Extentions;

namespace Web.Pages.Roles
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<WebIdentityUser> Members { get; set; }
        public IEnumerable<WebIdentityUser> NonMembers { get; set; }
    }
    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }
        public string RoleId { get; set; }
        public string[] AddIds { get; set; }
        public string[] DeleteIds { get; set; }
    }
    public class UpdateModel : PageModel
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<WebIdentityUser> _userManager;

        public RoleEdit RoleEdit { get; set; }
        [BindProperty]
        public RoleModification RoleModifcationModel { get; set; }

        public UpdateModel(RoleManager<IdentityRole> roleManager, UserManager<WebIdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        //public void OnGet()
        //{
        //    RoleEdit = new RoleEdit();
        //}

        public async Task OnGetAsync(string id)
        {
            if (id != null)
            {
                IdentityRole role = await _roleManager.FindByIdAsync(id);

               
                List<WebIdentityUser> members = new List<WebIdentityUser>();
                List<WebIdentityUser> nonMembers = new List<WebIdentityUser>();
                foreach (WebIdentityUser user in _userManager.Users)
                {
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        members.Add(user);
                    }
                    else
                    {
                        nonMembers.Add(user);
                    }
                }
                await _userManager.AddToRoleAsync(_userManager.ConvertToWebIdentityUser(User), "Admin");
               
                RoleEdit = new RoleEdit { Role = role, Members = members, NonMembers = nonMembers };
            }
        }
        public async Task<IActionResult> OnPostUpdateAsync()
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in RoleModifcationModel.AddIds ?? new string[] { })
                {
                    WebIdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, RoleModifcationModel.RoleName);
                        if (!result.Succeeded)
                        {
                            Errors(result);
                        }
                    }
                }
                foreach (string userId in RoleModifcationModel.DeleteIds ?? new string[] { })
                {
                    WebIdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, RoleModifcationModel.RoleName);
                        if (!result.Succeeded)
                        {
                            Errors(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToPage("../Roles/Index");
            else
                return RedirectToPage("../Roles/Update", RoleModifcationModel.RoleId);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
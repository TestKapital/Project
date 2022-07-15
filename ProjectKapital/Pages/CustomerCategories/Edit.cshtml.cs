using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.CustomerCategories
{
    public class EditModel : PageModel
    {
        private readonly ICustomerCategoryRepository _dbCustomerCategory;

        public EditModel(ICustomerCategoryRepository dbCustomerCategory)
        {
            _dbCustomerCategory = dbCustomerCategory;
        }

        [BindProperty]
        public CustomerCategory CustomerCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _dbCustomerCategory == null)
            {
                return NotFound();
            }

            var customerCategory = _dbCustomerCategory.GetFirstOrDefault(m => m.Category == id);
            if (customerCategory == null)
            {
                return NotFound();
            }
            CustomerCategory = customerCategory;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _dbCustomerCategory.Update(CustomerCategory);
                _dbCustomerCategory.Save();
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}

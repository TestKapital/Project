using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.CustomerCategories
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerCategoryRepository _dbCustomerCategory;

        public CreateModel(ICustomerCategoryRepository dbCustomerCategory)
        {
            _dbCustomerCategory = dbCustomerCategory;
        }


        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CustomerCategory CustomerCategory { get; set; } = default!;
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _dbCustomerCategory == null || CustomerCategory == null)
            {
                return Page();
            }

            _dbCustomerCategory.Add(CustomerCategory);
            _dbCustomerCategory.Save();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.CustomerCategories
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerCategoryRepository _dbCustomerCategory;

        public DetailsModel(ICustomerCategoryRepository dbCustomerCategory)
        {
            _dbCustomerCategory = dbCustomerCategory;
        }

        public CustomerCategory CustomerCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _dbCustomerCategory == null)
            {
                return NotFound();
            }

            var customerCategory = _dbCustomerCategory.GetFirstOrDefault(m => m.Id == id);
            if (customerCategory == null)
            {
                return NotFound();
            }
            else
            {
                CustomerCategory = customerCategory;
            }
            return Page();
        }
    }
}

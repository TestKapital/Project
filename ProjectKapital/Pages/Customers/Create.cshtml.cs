using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerRepository _dbCustomer;

        public CreateModel(ICustomerRepository dbCustomer)
        {
            _dbCustomer = dbCustomer;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
     
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _dbCustomer == null || Customer == null)
            {
                return Page();
            }

            _dbCustomer.Add(Customer);
            _dbCustomer.Save();

            return RedirectToPage("./Index");
        }
    }
}

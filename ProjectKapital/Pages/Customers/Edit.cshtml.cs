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

namespace ProjectKapital.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerRepository _dbCustomer;

        public EditModel(ICustomerRepository dbCustomer)
        {
            _dbCustomer = dbCustomer;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _dbCustomer == null)
            {
                return NotFound();
            }

            var customer =  _dbCustomer.GetFirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            Customer = customer;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _dbCustomer.Update(Customer);
                _dbCustomer.Save();
                return RedirectToPage("./Index");
            }

            return Page();
        }

    }
}

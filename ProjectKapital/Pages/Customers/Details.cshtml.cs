using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerRepository _dbCustomer;

        public DetailsModel(ICustomerRepository dbCustomer)
        {
            _dbCustomer = dbCustomer;
        }

        public Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _dbCustomer == null)
            {
                return NotFound();
            }

            var customer = _dbCustomer.GetFirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }
    }
}

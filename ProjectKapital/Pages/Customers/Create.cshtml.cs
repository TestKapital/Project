using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectK.DataAccess.Repository;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;

namespace ProjectKapital.Pages.Customers
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> CustomerCategories { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            CustomerCategories = _unitOfWork.CustomerCategory.GetAll().Select(i => new SelectListItem()
            {
                Text = i.CategoryName,
                Value = i.Id.ToString()
            });
            
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _unitOfWork == null || Customer == null)
            {
                return Page();
            }

            _unitOfWork.Customer.Add(Customer);
            _unitOfWork.Save();
            
            return RedirectToPage("./Index");
        }
    }
}

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
    public class DeleteModel : PageModel
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
            public CustomerCategory CustomerCategory { get; set; } = default!;

            public async Task<IActionResult> OnGetAsync(int? id)
            {
                if (id == null || _unitOfWork == null)
                {
                    return NotFound();
                }

                var customerCategory = _unitOfWork.CustomerCategory.GetFirstOrDefault(m => m.Id == id);

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

            public async Task<IActionResult> OnPostAsync(int? id)
            {
                if (id == null || _unitOfWork == null)
                {
                    return NotFound();
                }
                var customerCategory = _unitOfWork.CustomerCategory.GetFirstOrDefault(m => m.Id == id);

                if (customerCategory != null)
                {
                    CustomerCategory = customerCategory;
                    _unitOfWork.CustomerCategory.Remove(CustomerCategory);
                    _unitOfWork.Save();
                }

                return RedirectToPage("./Index");
            }
        }
    }

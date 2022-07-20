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
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<CustomerCategory> CustomerCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_unitOfWork != null)
            {
                CustomerCategory = (IList<CustomerCategory>)_unitOfWork.CustomerCategory.GetAll();
            }
        }
    }
}

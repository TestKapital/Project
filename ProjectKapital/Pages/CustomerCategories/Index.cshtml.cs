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
        private readonly ICustomerCategoryRepository _dbCustomerCategory;

        public IndexModel(ICustomerCategoryRepository dbCustomerCategory)
        {
            _dbCustomerCategory = dbCustomerCategory;
        }

        public IList<CustomerCategory> CustomerCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_dbCustomerCategory != null)
            {
                CustomerCategory = (IList<CustomerCategory>)_dbCustomerCategory.GetAll();
            }
        }
    }
}

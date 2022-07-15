using ProjectK.DataAccess.Data;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.DataAccess.Repository
{
    public class CustomerCategoryRepository : Repository<CustomerCategory>, ICustomerCategoryRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CustomerCategory customerCategory)
        {
            var ObjFromDb = _db.CustomerCategory.FirstOrDefault(u => u.CustomerCategoryId == customerCategory.CustomerCategoryId);
            ObjFromDb.CategoryName = customerCategory.CategoryName;
        }
    }
}

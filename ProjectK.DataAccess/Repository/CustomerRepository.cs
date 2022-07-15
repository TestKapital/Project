using ProjectK.DataAccess.Data;
using ProjectK.DataAccess.Repository.IRepository;
using ProjectKapital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectKapital.Models.Customer;

namespace ProjectK.DataAccess.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _db;
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _db = context;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var ObjFromDb = _db.Customer.FirstOrDefault(u => u.Id == customer.Id);
            ObjFromDb.FirstName = customer.FirstName;
            ObjFromDb.LastName = customer.LastName;
            ObjFromDb.Birthday = customer.Birthday;
            ObjFromDb.Gender = customer.Gender;
            ObjFromDb.CustomerCategoryId = customer.CustomerCategoryId;
            ObjFromDb.PhoneNumber = customer.PhoneNumber;
            ObjFromDb.Credit = customer.Credit;
        }
    }
}

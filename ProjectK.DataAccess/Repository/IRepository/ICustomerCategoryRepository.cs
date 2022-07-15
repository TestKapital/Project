using ProjectKapital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.DataAccess.Repository.IRepository
{
    public interface ICustomerCategoryRepository : IRepository<CustomerCategory>
    {
        void Update(CustomerCategory customerCategory);
        void Save();
    }
}

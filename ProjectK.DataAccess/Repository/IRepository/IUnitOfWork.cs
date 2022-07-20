using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectK.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customer { get; }
        ICustomerCategoryRepository CustomerCategory { get; }
        void Save();
    }
}

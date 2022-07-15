using Microsoft.EntityFrameworkCore;
using ProjectKapital.Models;

namespace ProjectK.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerCategory> CustomerCategory { get; set; }
    }
}

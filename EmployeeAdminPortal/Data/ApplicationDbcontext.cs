using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbcontext : DbContext
    {
        //public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        //{

        //}
        public ApplicationDbcontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

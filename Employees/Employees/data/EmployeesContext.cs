using Employees.model;
using Employees.model.domain;
using Microsoft.EntityFrameworkCore;

namespace Employees.data
{
    public class EmployeesContext : DbContext
    {
        public EmployeesContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }




        public DbSet<Departments> Departments { get; set; }
        public DbSet<countries> countries { get; set; }
        public DbSet<dependents> dependents { get; set; }
        public DbSet<employees> employees { get; set; }
        public DbSet<jobs> jobs { get; set; }
        public DbSet<location> locations { get; set; }

        public DbSet<regions> regions { get; set; }

    }
       

    
}

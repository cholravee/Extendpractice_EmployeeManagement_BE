using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.EFCore
{
    public class EF_DataContext : DbContext
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Job { get; set; }
    }
}

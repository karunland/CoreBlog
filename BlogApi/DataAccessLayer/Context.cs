using Microsoft.EntityFrameworkCore;

namespace BlogApi.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=blogsiteApi;" +
                "integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

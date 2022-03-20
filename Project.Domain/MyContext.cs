using Microsoft.EntityFrameworkCore;
using Project.Domain.Model;

namespace Project.Domain;
public class MyContext: DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseSqlServer(@"{ your database connection string }");
    }
}

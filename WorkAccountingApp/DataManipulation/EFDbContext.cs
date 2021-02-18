using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using WorkAccountingApp.Models;

namespace WorkAccountingApp.DataManipulation
{
    public class EFDbContext : DbContext
    {
        public DbSet<City> Cities { get; set; } 
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EFDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "accounting.db"};
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            optionsBuilder.UseSqlite(connection);
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
    }
}

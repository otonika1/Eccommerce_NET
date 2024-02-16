using Eccommerce.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eccommerce.API.DB
{
    public class EmployeeDB : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<CompanyEntity> Company { get; set; }
        
        public EmployeeDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
using EL_KooD_API.Data.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EL_KooD_API.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Main_Branch> Main_Branches { get; set; }
        public DbSet<Secondary_Branch> Secondary_Branches { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturing_Process> Manufacturing_Processes { get; set; }
        public DbSet<Supply_Process> Supply_Processes { get; set; }
    }
}

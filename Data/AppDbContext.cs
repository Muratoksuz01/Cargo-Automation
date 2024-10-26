using Microsoft.EntityFrameworkCore;
using Cargo.Models;

namespace Cargo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CargoModel> Cargos { get; set; } // Cargo sınıfı yerine CargoModel
        public DbSet<BUser> BUsers { get; set; }
        public DbSet<KUser> Users { get; set; }
    }
}

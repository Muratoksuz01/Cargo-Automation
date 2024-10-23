using Microsoft.EntityFrameworkCore;
using Cargo.Models;

namespace Cargo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<BUser> BUsers { get; set; }
    }
}

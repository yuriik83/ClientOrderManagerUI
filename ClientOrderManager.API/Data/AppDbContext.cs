using Microsoft.EntityFrameworkCore;
using ClientOrderManager.API.Models;

namespace ClientOrderManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
    }
}
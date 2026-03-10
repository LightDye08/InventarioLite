using Microsoft.EntityFrameworkCore;
using ProductosApp.Models;

namespace ProductosApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Producto> Productos => Set<Producto>();
    }
}

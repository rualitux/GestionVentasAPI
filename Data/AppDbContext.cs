using Microsoft.EntityFrameworkCore;
using CJeanPIerreAPI.Models;

namespace CJeanPIerreAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Inventario> Inventarios => Set<Inventario>();
        public DbSet<Proveedor> Proveedors => Set<Proveedor>();
        public DbSet<Compra> Compras => Set<Compra>();
        public DbSet<CompraDetalle> CompraDetalles => Set<CompraDetalle>();
        public DbSet<Area> Areas => Set<Area>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Producto>()
                .HasMany(p => p.CompraDetalles)
                .WithOne(p => p.Producto!)
                .HasForeignKey(p => p.ProductoId);

            modelBuilder
                .Entity<Proveedor>()
                .HasMany(p => p.Compras)
                .WithOne(p => p.Proveedor!)
                .HasForeignKey(p => p.ProveedorId);
        }



            /// <summary>
            /// Do any database initialization required.
            /// </summary>
            /// <returns>A task that completes when the database is initialized</returns>
            //public async Task InitializeDatabaseAsync()
            //{
            //    await this.Database.EnsureCreatedAsync().ConfigureAwait(false);
            //}
        }
}
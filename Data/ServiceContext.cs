using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Entitites.Entities;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<Detalles_Pedido> Detalles { get; set; }
        public DbSet<ClientesItem> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("Products");
            });

            builder.Entity<ClientesItem>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(u => u.ClienteId);
            });

            builder.Entity<Detalles_Pedido>(entity =>
            {
                entity.ToTable("Detalles");
                entity.HasKey(d => d.IdPedido);

                entity.HasOne<ClientesItem>()
                      .WithMany()
                      .HasForeignKey(d => d.IdCliente)
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }





}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitites.Entities;
using System.Reflection.Emit;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<Detalles_Pedido> Detalles { get; set; }
        public DbSet<ClientesItem> Clientes { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<RollItem> RollItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)

        { 
            builder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.IdProducto); // Configuración de la clave primaria

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
                entity.HasOne<ClientesItem>().WithMany().HasForeignKey(d => d.IdCliente);
    // No es necesario OnDelete(DeleteBehavior.Restrict) si quieres que la eliminación de cliente no afecte a los detalles de los pedidos.
            });

            builder.Entity<UserItem>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(u => u.IdUsuario);
                entity.HasOne<RollItem>().WithMany().HasForeignKey(u => u.IdRoll);
            });

            builder.Entity<RollItem>(entity =>
            {
                entity.ToTable("RollUser");
                entity.HasKey(u => u.IdRoll);
            });

        }

        public bool RemoveUserById(int userId)
        {
            var userToRemove = Users.FirstOrDefault(u => u.IdUsuario == userId);
            if (userToRemove != null)
            {
                Users.Remove(userToRemove);
                SaveChanges();
                return true;
            }

            return false;
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

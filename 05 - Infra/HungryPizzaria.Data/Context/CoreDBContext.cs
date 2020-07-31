using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace HungryPizzaria.Data.Operation.Context
{
    public class CoreDbContext : DbContext
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            optionsBuilder.UseSqlServer(config.GetConnectionString("CoreConnection"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappings.Projeto.ClienteMap());
            modelBuilder.ApplyConfiguration(new Mappings.Projeto.PedidosMap());
            modelBuilder.ApplyConfiguration(new Mappings.Projeto.ItensPedidoMap());
            modelBuilder.ApplyConfiguration(new Mappings.Projeto.PizzaSaboresMap());

        }


        public DbSet<Domain.Operation.Entities.Projeto.Cliente> Cliente { get; set; }
        public DbSet<Domain.Operation.Entities.Projeto.Pedidos> Pedidos { get; set; }
        public DbSet<Domain.Operation.Entities.Projeto.ItensPedido> ItensPedido { get; set; }
        public DbSet<Domain.Operation.Entities.Projeto.PizzaSabores> PizzaSabores { get; set; }


    }
}

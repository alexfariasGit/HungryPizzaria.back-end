using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Data.Operation.Mappings.Projeto
{
    public class PedidosMap : IEntityTypeConfiguration<Domain.Operation.Entities.Projeto.Pedidos>
    {
        public void Configure(EntityTypeBuilder<Domain.Operation.Entities.Projeto.Pedidos> builder)
        {
            builder.ToTable("Pedidos", "Projeto");
            
            builder.HasKey(c => c.IDPEDIDOS).HasName("IDPEDIDOS");
            builder.Property(c => c.IDPEDIDOS).HasColumnName("IDPEDIDOS")
                .ValueGeneratedOnAdd();                      

            builder.Property(c => c.IDCLIENTE)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder.Property(c => c.TOTAL)
                .HasColumnName("TOTAL");
      

            builder.Property(c => c.DTINCLUSAO)
                .HasColumnName("DTINCLUSAO");

            builder.HasOne(x => x.Cliente)
               .WithMany(x => x.Pedidos)
               .HasForeignKey(x => x.IDCLIENTE).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ItensPedidos)
            .WithOne(x => x.Pedidos)
            .HasForeignKey(x => x.IDPEDIDOS).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

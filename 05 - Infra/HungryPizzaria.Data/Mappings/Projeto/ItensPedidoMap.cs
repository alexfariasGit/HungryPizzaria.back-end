using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Data.Operation.Mappings.Projeto
{
    public class ItensPedidoMap : IEntityTypeConfiguration<Domain.Operation.Entities.Projeto.ItensPedido>
    {
        public void Configure(EntityTypeBuilder<Domain.Operation.Entities.Projeto.ItensPedido> builder)
        {
            builder.ToTable("ITENS_PEDIDOS", "Projeto");
            
            builder.HasKey(c => c.IDITENSPEDIDOS).HasName("IDITENSPEDIDOS");
            builder.Property(c => c.IDITENSPEDIDOS).HasColumnName("IDITENSPEDIDOS")
                .ValueGeneratedOnAdd();                      

            builder.Property(c => c.IDPEDIDOS)
                .HasColumnName("IDPEDIDOS")
                .IsRequired();

            builder.Property(c => c.IDPIZZA)
               .HasColumnName("IDPIZZA")
               .IsRequired();

            builder.Property(c => c.INTEIRA)
               .HasColumnName("INTEIRA");

            builder.Property(c => c.TOTAL)
                .HasColumnName("TOTAL");
      

            builder.Property(c => c.DTINCLUSAO)
                .HasColumnName("DTINCLUSAO");

            builder.HasOne(x => x.Pedidos)
               .WithMany(x => x.ItensPedidos)
               .HasForeignKey(x => x.IDPEDIDOS).OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(x => x.PizzaSabores)
            //.WithOne(x => x.ItensPedido)
            //.HasForeignKey(x => x.IDPIZZA).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

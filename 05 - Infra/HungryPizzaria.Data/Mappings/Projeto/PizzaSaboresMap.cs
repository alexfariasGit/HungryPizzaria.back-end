using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Data.Operation.Mappings.Projeto
{
    public class PizzaSaboresMap : IEntityTypeConfiguration<Domain.Operation.Entities.Projeto.PizzaSabores>
    {
        public void Configure(EntityTypeBuilder<Domain.Operation.Entities.Projeto.PizzaSabores> builder)
        {
            builder.ToTable("PIZZA_SABORES", "Projeto");
            
            builder.HasKey(c => c.IDPIZZA).HasName("IDPIZZA");
            builder.Property(c => c.IDPIZZA).HasColumnName("IDPIZZA")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.DESCRICAO).HasColumnName("DESCRICAO")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(c => c.VALORES)
                .HasColumnName("VALORES");

            builder.Property(c => c.STATUS)
               .HasColumnName("STATUS");


            builder.Property(c => c.DTINCLUSAO)
                .HasColumnName("DTINCLUSAO");

            builder.Property(c => c.DTALTERACAO)
               .HasColumnName("DTALTERACAO");

            builder.HasMany(x => x.ItensPedido)
               .WithOne(x => x.PizzaSabores)
               .HasForeignKey(x => x.IDPIZZA).OnDelete(DeleteBehavior.Restrict);


        }
    }
}

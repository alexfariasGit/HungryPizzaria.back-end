using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HungryPizzaria.Data.Operation.Mappings.Projeto
{
    public class ClienteMap : IEntityTypeConfiguration<Domain.Operation.Entities.Projeto.Cliente>
    {
        public void Configure(EntityTypeBuilder<Domain.Operation.Entities.Projeto.Cliente> builder)
        {
            builder.ToTable("Cliente", "Projeto");
            
            builder.HasKey(c => c.IDCLIENTE).HasName("IDCLIENTE");
            builder.Property(c => c.IDCLIENTE).HasColumnName("IDCLIENTE")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.CPF).HasColumnName("CPF")
              .HasMaxLength(15)
              .IsRequired();

            builder.Property(c => c.NOME).HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.TELEFONE).HasColumnName("TELEFONE")
              .HasMaxLength(15)
              .IsRequired();

            builder.Property(c => c.DTNASCIMENTO).HasColumnName("DTNASCIMENTO")
                .IsRequired();

            builder.Property(c => c.LOGRADOURO).HasColumnName("LOGRADOURO")
             .HasMaxLength(250)
             .IsRequired();

            builder.Property(c => c.NUMERO).HasColumnName("NUMERO");

            builder.Property(c => c.COMPLEMENTO).HasColumnName("COMPLEMENTO")
             .HasMaxLength(50);

            builder.Property(c => c.BAIRRO).HasColumnName("BAIRRO")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(c => c.CIDADE).HasColumnName("CIDADE")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(c => c.UF).HasColumnName("UF")
            .HasMaxLength(2)
            .IsRequired();

            builder.Property(c => c.DTINCLUSAO)
                .HasColumnName("DTINCLUSAO");

            builder.Property(c => c.DTALTERACAO)
                .HasColumnName("DTALTERACAO");

            builder.HasMany(x => x.Pedidos)
             .WithOne(x => x.Cliente)
             .HasForeignKey(x => x.IDCLIENTE).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

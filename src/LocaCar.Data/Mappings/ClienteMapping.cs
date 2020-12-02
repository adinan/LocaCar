using LocaCar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaCar.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Cpf)
              .IsRequired()
              .HasColumnType("varchar(11)");

            // 1 : N => Cliente : Locacoes
            builder.HasMany(c => c.Locacoes)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId);


            builder.ToTable("Clientes");
        }
    }
}
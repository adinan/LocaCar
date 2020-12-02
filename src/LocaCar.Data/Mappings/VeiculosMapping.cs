using LocaCar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaCar.Data.Mappings
{
    public class VeiculosMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Marca)
                .IsRequired();

            builder.Property(p => p.Modelo)
                .IsRequired();

            builder.Property(p => p.Placa)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.AnoFabricacao)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(p => p.AnoModelo)
                .IsRequired()
                .HasColumnType("int");


            builder.ToTable("Veiculos");
        }
    }
}
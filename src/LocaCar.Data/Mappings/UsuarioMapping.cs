using LocaCar.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocaCar.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Senha)
                .IsRequired()
                .HasColumnType("varchar(256)");

            builder.Property(c => c.Login)
                .IsRequired()
                .HasColumnType("varchar(20)");
             
            builder.ToTable("Usuarios");
        }
    }
}
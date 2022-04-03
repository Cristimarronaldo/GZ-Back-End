using Gazin.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gazin.Infra.Data.Mappings
{
    public class NiveisMapping : IEntityTypeConfiguration<Niveis>
    {
        public void Configure(EntityTypeBuilder<Niveis> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nivel)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Id)
                .HasDefaultValueSql("NEXT VALUE FOR NiveisSequencia");

            builder.HasMany(n => n.Desenvolvedor)
                .WithOne(n => n.Niveis)
                .HasForeignKey(n => n.NivelId);

            builder.ToTable("Niveis");
        }
    }
}

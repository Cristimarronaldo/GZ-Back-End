using Gazin.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gazin.Infra.Data.Mappings
{
    public class DesenvolvedorMapping : IEntityTypeConfiguration<Desenvolvedor>
    {
        public void Configure(EntityTypeBuilder<Desenvolvedor> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(d => d.NivelId)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(d => d.Sexo).HasColumnType("char(1)");

            builder.Property(d => d.DataNascimento).HasColumnType("DateTime");

            builder.Property(d => d.Idade).HasColumnType("int");

            builder.Property(d => d.Hobby).HasColumnType("Varchar(60)");

            builder.Property(d => d.Id)
                .HasDefaultValueSql("NEXT VALUE FOR DesenvolvedorSequencia");

            builder.ToTable("Desenvolvedores");
        }
    }
}

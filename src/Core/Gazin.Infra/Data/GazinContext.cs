using Gazin.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace Gazin.Infra.Data
{
    public class GazinContext : DbContext
    {
        public GazinContext(DbContextOptions<GazinContext> options)
            : base(options)
        {            
        }

        public DbSet<Niveis> Niveis { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
            
            

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GazinContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.HasSequence<int>("NiveisSequencia").StartsAt(1).IncrementsBy(1);
            modelBuilder.HasSequence<int>("DesenvolvedorSequencia").StartsAt(1).IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }
    }
}

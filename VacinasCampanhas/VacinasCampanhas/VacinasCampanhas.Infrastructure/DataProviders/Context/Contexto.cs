using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
    {

    }

    public DbSet<Vacina> Vacinas { get; set; }

    public DbSet<Campanha> Campanhas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campanha>()
            .HasOne(v => v.Vacina)
            .WithMany(c => c.Campanhas)
            .HasForeignKey(f => f.VacinaId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Vacina>()
           .HasIndex(v => v.NomeDaVacina)
           .IsUnique();

        modelBuilder.Entity<Campanha>()
            .HasIndex(c => c.NomeDaCampanha)
            .IsUnique();
    }

}

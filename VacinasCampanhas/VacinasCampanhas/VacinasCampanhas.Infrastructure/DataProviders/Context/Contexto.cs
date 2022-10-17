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
            .HasOne(v => v.Vacina)             // nav property in Campanha class
            .WithMany(c => c.Campanhas);       // nav property in Vacina class
    }

}

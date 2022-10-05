using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Entities;

namespace VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
    {

    }

    public DbSet<Vacina>? Vacinas { get; set; }

    public DbSet<Campanha>? Campanhas { get; set; }

}

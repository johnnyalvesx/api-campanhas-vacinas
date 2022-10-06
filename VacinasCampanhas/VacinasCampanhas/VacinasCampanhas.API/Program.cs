using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Implementations;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Contexto>(opcoes =>
{
    opcoes.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vacinascampanhasDB;");
});

builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
builder.Services.AddScoped<IVacinaManager, VacinaManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using VacinasCampanhas.VacinasCampanhas.API.Configurations;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Implementations;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddFluentValidationConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(opcoes =>
{
    opcoes.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vacinascampanhasDB;");
});

builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
builder.Services.AddScoped<IVacinaManager, VacinaManager>();

builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

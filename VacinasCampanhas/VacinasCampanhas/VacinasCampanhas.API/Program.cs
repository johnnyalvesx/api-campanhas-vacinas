using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using VacinasCampanhas.VacinasCampanhas.Application.Validators;
using VacinasCampanhas.VacinasCampanhas.Domain.Abstractions;
using VacinasCampanhas.VacinasCampanhas.Domain.Implementations;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
})
    .AddFluentValidation(p => p.RegisterValidatorsFromAssemblyContaining<VacinaValidator>());

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<Contexto>(opcoes =>
{
    opcoes.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=vacinascampanhasDB;");
});

builder.Services.AddScoped<IVacinaRepository, VacinaRepository>();
builder.Services.AddScoped<IVacinaManager, VacinaManager>();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vacinas e Campanhas", Version = "v1" });
//});
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

//app.UseSwaggerUI( c => {
//    c.RoutePrefix = String.Empty;
//    c.SwaggerEndpoint(".swagger/v1/swagger.json", "CV V1");
//});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

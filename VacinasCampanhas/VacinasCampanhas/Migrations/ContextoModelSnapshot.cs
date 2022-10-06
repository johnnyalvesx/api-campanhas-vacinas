﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VacinasCampanhas.VacinasCampanhas.Infrastructure.DataProviders.Context;

#nullable disable

namespace VacinasCampanhas.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Campanha", b =>
                {
                    b.Property<int?>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CampanhaId"), 1L, 1);

                    b.Property<DateTime?>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataDeTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDaCampanha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusDaCampanha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampanhaId");

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Vacina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DicaDaVacina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDaVacina")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacinas");
                });
#pragma warning restore 612, 618
        }
    }
}

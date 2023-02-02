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
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Campanha", b =>
                {
                    b.Property<int>("CampanhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampanhaId"), 1L, 1);

                    b.Property<DateTime>("DataDeInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataDeTermino")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomeDaCampanha")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StatusDaCampanha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.HasKey("CampanhaId");

                    b.HasIndex("NomeDaCampanha")
                        .IsUnique();

                    b.ToTable("Campanhas");
                });

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Vacina", b =>
                {
                    b.Property<int>("VacinaId")
                        .HasColumnType("int");

                    b.Property<string>("DicaDaVacina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDaVacina")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("VacinaId");

                    b.HasIndex("NomeDaVacina")
                        .IsUnique();

                    b.ToTable("Vacinas");
                });

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Vacina", b =>
                {
                    b.HasOne("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Campanha", "Campanhas")
                        .WithOne("Vacina")
                        .HasForeignKey("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Vacina", "VacinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campanhas");
                });

            modelBuilder.Entity("VacinasCampanhas.VacinasCampanhas.Domain.Entities.Campanha", b =>
                {
                    b.Navigation("Vacina")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRUDAPI.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("CRUDAPI.Models.Vacina", b =>
                {
                    b.Property<int>("VacinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Dica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeDaVacina")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VacinaId");

                    b.ToTable("Vacinas");
                });
#pragma warning restore 612, 618
        }
    }
}

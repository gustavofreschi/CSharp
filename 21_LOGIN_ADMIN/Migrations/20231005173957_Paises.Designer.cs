﻿// <auto-generated />
using Exemplo02.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Exemplo02.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231005173957_Paises")]
    partial class Paises
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Exemplo02.Models.Continente", b =>
                {
                    b.Property<int>("continenteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("continenteID");

                    b.ToTable("Continentes");
                });

            modelBuilder.Entity("Exemplo02.Models.Pais", b =>
                {
                    b.Property<int>("IdPaises")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Populacao")
                        .HasColumnType("TEXT");

                    b.Property<int>("continenteID")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdPaises");

                    b.HasIndex("continenteID");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("Exemplo02.Models.Pais", b =>
                {
                    b.HasOne("Exemplo02.Models.Continente", "Continente")
                        .WithMany("Paises")
                        .HasForeignKey("continenteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continente");
                });

            modelBuilder.Entity("Exemplo02.Models.Continente", b =>
                {
                    b.Navigation("Paises");
                });
#pragma warning restore 612, 618
        }
    }
}

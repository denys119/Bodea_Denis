﻿// <auto-generated />
using System;
using Bodea_Denis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bodea_Denis.Migrations
{
    [DbContext(typeof(Bodea_DenisContext))]
    partial class Bodea_DenisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bodea_Denis.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeAngajat")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("Bodea_Denis.Models.Dotare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DotareNume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dotare");
                });

            modelBuilder.Entity("Bodea_Denis.Models.Masina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("An")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AngajatID")
                        .HasColumnType("int");

                    b.Property<string>("Culoare")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAdaugare")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.ToTable("Masina");
                });

            modelBuilder.Entity("Bodea_Denis.Models.MasinaDotare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DotareID")
                        .HasColumnType("int");

                    b.Property<int>("MasinaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DotareID");

                    b.HasIndex("MasinaID");

                    b.ToTable("MasinaDotare");
                });

            modelBuilder.Entity("Bodea_Denis.Models.Masina", b =>
                {
                    b.HasOne("Bodea_Denis.Models.Angajat", "Angajat")
                        .WithMany("Masini")
                        .HasForeignKey("AngajatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bodea_Denis.Models.MasinaDotare", b =>
                {
                    b.HasOne("Bodea_Denis.Models.Dotare", "Dotare")
                        .WithMany("MasinaDotari")
                        .HasForeignKey("DotareID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bodea_Denis.Models.Masina", "Masina")
                        .WithMany("MasinaDotari")
                        .HasForeignKey("MasinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

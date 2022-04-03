﻿// <auto-generated />
using System;
using Gazin.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gazin.Infra.Migrations
{
    [DbContext(typeof(GazinContext))]
    [Migration("20220330085718_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.HasSequence<int>("DesenvolvedorSequencia");

            modelBuilder.HasSequence<int>("NiveisSequencia");

            modelBuilder.Entity("Gazin.Dominio.Models.Desenvolvedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR DesenvolvedorSequencia");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("DateTime");

                    b.Property<string>("Hobby")
                        .IsRequired()
                        .HasColumnType("Varchar(60)");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<int>("NivelId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.HasKey("Id");

                    b.HasIndex("NivelId");

                    b.ToTable("Desenvolvedores", (string)null);
                });

            modelBuilder.Entity("Gazin.Dominio.Models.Niveis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR NiveisSequencia");

                    b.Property<string>("Nivel")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Niveis", (string)null);
                });

            modelBuilder.Entity("Gazin.Dominio.Models.Desenvolvedor", b =>
                {
                    b.HasOne("Gazin.Dominio.Models.Niveis", "Niveis")
                        .WithMany("Desenvolvedor")
                        .HasForeignKey("NivelId")
                        .IsRequired();

                    b.Navigation("Niveis");
                });

            modelBuilder.Entity("Gazin.Dominio.Models.Niveis", b =>
                {
                    b.Navigation("Desenvolvedor");
                });
#pragma warning restore 612, 618
        }
    }
}
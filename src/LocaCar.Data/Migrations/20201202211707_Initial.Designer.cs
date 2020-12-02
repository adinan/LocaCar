﻿// <auto-generated />
using System;
using LocaCar.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LocaCar.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20201202211707_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LocaCar.Business.Models.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("Locacoes");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Locacao", b =>
                {
                    b.HasOne("LocaCar.Business.Models.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("ClienteId")
                        .IsRequired();

                    b.HasOne("LocaCar.Business.Models.Veiculo", "Veiculo")
                        .WithMany("Locacoes")
                        .HasForeignKey("VeiculoId")
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Cliente", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("LocaCar.Business.Models.Veiculo", b =>
                {
                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}

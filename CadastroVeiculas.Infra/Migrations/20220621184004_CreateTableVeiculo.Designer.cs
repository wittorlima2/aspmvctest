﻿// <auto-generated />
using System;
using CadastroVeiculos.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CadastroVeiculos.Infra.Data.Migrations
{
    [DbContext(typeof(CadastroVeiculosContext))]
    [Migration("20220621184004_CreateTableVeiculo")]
    partial class CreateTableVeiculo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CadastroVeiculos.Domain.Entities.Marca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_nome");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("nb_status");

                    b.HasKey("Id");

                    b.ToTable("marca");
                });

            modelBuilder.Entity("CadastroVeiculos.Domain.Entities.Proprietario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_documento");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_email");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_endereco");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_nome");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("nb_status");

                    b.HasKey("Id");

                    b.ToTable("proprietario");
                });

            modelBuilder.Entity("CadastroVeiculos.Domain.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int")
                        .HasColumnName("nb_ano_fabricacao");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int")
                        .HasColumnName("nb_ano_modelo");

                    b.Property<Guid>("MarcaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Modelo")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_modelo");

                    b.Property<Guid>("ProprietarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quilometragem")
                        .HasColumnType("int")
                        .HasColumnName("nb_quilometragem");

                    b.Property<string>("RENAVAM")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("tx_renavam");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("nb_status");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("nb_valor");

                    b.Property<Guid?>("marca_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("proprietario_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("marca_id");

                    b.HasIndex("proprietario_id");

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("CadastroVeiculos.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("CadastroVeiculos.Domain.Entities.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("marca_id");

                    b.HasOne("CadastroVeiculos.Domain.Entities.Proprietario", "Proprietario")
                        .WithMany()
                        .HasForeignKey("proprietario_id");

                    b.Navigation("Marca");

                    b.Navigation("Proprietario");
                });
#pragma warning restore 612, 618
        }
    }
}

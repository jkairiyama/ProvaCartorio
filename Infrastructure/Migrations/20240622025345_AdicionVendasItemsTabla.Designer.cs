﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(TestCartorioDbContext))]
    [Migration("20240622025345_AdicionVendasItemsTabla")]
    partial class AdicionVendasItemsTabla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Data.Clientes.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ClienteId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Domain.Data.Produtos.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<int>("Estoque")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Domain.Data.Vendas.Entities.VendaItem", b =>
                {
                    b.Property<int>("VendaItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VendaItemId"));

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<int>("VendaId")
                        .HasColumnType("integer");

                    b.HasKey("VendaItemId");

                    b.HasIndex("VendaId");

                    b.ToTable("VendaItems");
                });

            modelBuilder.Entity("Domain.Data.Vendas.Venda", b =>
                {
                    b.Property<int>("VendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VendaId"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("VendaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Domain.Data.Vendas.Entities.VendaItem", b =>
                {
                    b.HasOne("Domain.Data.Vendas.Venda", null)
                        .WithMany("Items")
                        .HasForeignKey("VendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Data.Vendas.Venda", b =>
                {
                    b.HasOne("Domain.Data.Clientes.Cliente", null)
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Data.Clientes.Cliente", b =>
                {
                    b.Navigation("Vendas");
                });

            modelBuilder.Entity("Domain.Data.Vendas.Venda", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}

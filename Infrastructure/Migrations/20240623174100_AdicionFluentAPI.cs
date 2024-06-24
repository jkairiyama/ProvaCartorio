using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionFluentAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Vendas",
                newName: "Vendas",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "VendaItems",
                newName: "VendaItems",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produtos",
                newSchema: "public");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Clientes",
                newSchema: "public");

            migrationBuilder.CreateSequence(
                name: "clienteseq",
                schema: "public",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "produtoseq",
                schema: "public",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "vendaitemseq",
                schema: "public",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "vendaseq",
                schema: "public",
                incrementBy: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                schema: "public",
                table: "Vendas",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                schema: "public",
                table: "Vendas",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                schema: "public",
                table: "Vendas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "VendaItemId",
                schema: "public",
                table: "VendaItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                schema: "public",
                table: "Produtos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                schema: "public",
                table: "Clientes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_Data",
                schema: "public",
                table: "Vendas",
                column: "Data",
                descending: new bool[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                schema: "public",
                table: "Vendas",
                column: "ClienteId",
                principalSchema: "public",
                principalTable: "Clientes",
                principalColumn: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                schema: "public",
                table: "Vendas");

            migrationBuilder.DropIndex(
                name: "IX_Vendas_Data",
                schema: "public",
                table: "Vendas");

            migrationBuilder.DropSequence(
                name: "clienteseq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "produtoseq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "vendaitemseq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "vendaseq",
                schema: "public");

            migrationBuilder.RenameTable(
                name: "Vendas",
                schema: "public",
                newName: "Vendas");

            migrationBuilder.RenameTable(
                name: "VendaItems",
                schema: "public",
                newName: "VendaItems");

            migrationBuilder.RenameTable(
                name: "Produtos",
                schema: "public",
                newName: "Produtos");

            migrationBuilder.RenameTable(
                name: "Clientes",
                schema: "public",
                newName: "Clientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Data",
                table: "Vendas",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Vendas",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VendaId",
                table: "Vendas",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "VendaItemId",
                table: "VendaItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ProdutoId",
                table: "Produtos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Clientes",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

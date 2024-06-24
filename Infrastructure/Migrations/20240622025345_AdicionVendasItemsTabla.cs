using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdicionVendasItemsTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItem_Vendas_VendaId",
                table: "VendaItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendaItem",
                table: "VendaItem");

            migrationBuilder.RenameTable(
                name: "VendaItem",
                newName: "VendaItems");

            migrationBuilder.RenameIndex(
                name: "IX_VendaItem_VendaId",
                table: "VendaItems",
                newName: "IX_VendaItems_VendaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendaItems",
                table: "VendaItems",
                column: "VendaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItems_Vendas_VendaId",
                table: "VendaItems",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItems_Vendas_VendaId",
                table: "VendaItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendaItems",
                table: "VendaItems");

            migrationBuilder.RenameTable(
                name: "VendaItems",
                newName: "VendaItem");

            migrationBuilder.RenameIndex(
                name: "IX_VendaItems_VendaId",
                table: "VendaItem",
                newName: "IX_VendaItem_VendaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendaItem",
                table: "VendaItem",
                column: "VendaItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItem_Vendas_VendaId",
                table: "VendaItem",
                column: "VendaId",
                principalTable: "Vendas",
                principalColumn: "VendaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFramework.Estudo.Migrations
{
    /// <inheritdoc />
    public partial class Table_ImagensProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagensProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Des_Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Des_Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Seq_Produt",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagensProdutos_ProdutoId",
                table: "ImagensProdutos",
                column: "ProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensProdutos");
        }
    }
}

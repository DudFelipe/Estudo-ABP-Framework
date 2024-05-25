using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFramework.Estudo.Migrations
{
    /// <inheritdoc />
    public partial class Tabela_Categorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Seq_Catego = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Des_Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Des_Descri = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Seq_Catego);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}

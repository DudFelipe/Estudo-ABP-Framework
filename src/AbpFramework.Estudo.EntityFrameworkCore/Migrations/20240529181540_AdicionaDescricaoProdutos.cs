using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFramework.Estudo.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaDescricaoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Des_Descri",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Des_Descri",
                table: "Produtos");
        }
    }
}

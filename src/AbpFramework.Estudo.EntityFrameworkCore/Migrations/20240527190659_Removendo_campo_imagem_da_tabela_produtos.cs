using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFramework.Estudo.Migrations
{
    /// <inheritdoc />
    public partial class Removendo_campo_imagem_da_tabela_produtos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Val_Imagem",
                table: "Produtos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Val_Imagem",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

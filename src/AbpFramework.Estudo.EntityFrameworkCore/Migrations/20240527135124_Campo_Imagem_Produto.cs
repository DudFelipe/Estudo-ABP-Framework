using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbpFramework.Estudo.Migrations
{
    /// <inheritdoc />
    public partial class Campo_Imagem_Produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Val_Imagem",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Val_Imagem",
                table: "Produtos");
        }
    }
}

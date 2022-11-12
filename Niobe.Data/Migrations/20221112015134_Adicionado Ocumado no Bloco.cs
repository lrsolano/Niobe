using Microsoft.EntityFrameworkCore.Migrations;

namespace Niobe.Data.Migrations
{
    public partial class AdicionadoOcumadonoBloco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ocupado",
                table: "Blocos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ocupado",
                table: "Blocos");
        }
    }
}

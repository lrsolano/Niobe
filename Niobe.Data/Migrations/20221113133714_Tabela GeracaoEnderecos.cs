using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Niobe.Data.Migrations
{
    public partial class TabelaGeracaoEnderecos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeradorEndereços",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdArmazem = table.Column<long>(type: "bigint", nullable: false),
                    NomeRua = table.Column<string>(type: "text", nullable: false),
                    CodigoRua = table.Column<string>(type: "text", nullable: true),
                    TipoRua = table.Column<int>(type: "int", nullable: false),
                    QuantidadeRua = table.Column<long>(type: "bigint", nullable: false),
                    NomeColuna = table.Column<string>(type: "text", nullable: false),
                    CodigoColuna = table.Column<string>(type: "text", nullable: true),
                    TipoColuna = table.Column<int>(type: "int", nullable: false),
                    QuantidadeColuna = table.Column<long>(type: "bigint", nullable: false),
                    NomeNivel = table.Column<string>(type: "text", nullable: false),
                    CodigoNivel = table.Column<string>(type: "text", nullable: true),
                    TipoNivel = table.Column<int>(type: "int", nullable: false),
                    QuantidadeNivel = table.Column<long>(type: "bigint", nullable: false),
                    NomeBloco = table.Column<string>(type: "text", nullable: false),
                    CodigoBloco = table.Column<string>(type: "text", nullable: true),
                    BlocoAB = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    QuantidadeBloco = table.Column<long>(type: "bigint", nullable: false),
                    PadraoEndereco = table.Column<string>(type: "text", nullable: false),
                    OrdemRua = table.Column<long>(type: "bigint", nullable: false),
                    OrdemColuna = table.Column<long>(type: "bigint", nullable: false),
                    OrdemNivel = table.Column<long>(type: "bigint", nullable: false),
                    OrdemBloco = table.Column<long>(type: "bigint", nullable: false),
                    GeracaoCompletada = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeradorEndereços", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeradorEndereços");
        }
    }
}

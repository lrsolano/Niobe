using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Niobe.Data.Migrations
{
    public partial class AdicionandoRestanteArmazem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ruas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdArmazem = table.Column<long>(type: "bigint", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ordem = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ruas_Armazems_IdArmazem",
                        column: x => x.IdArmazem,
                        principalTable: "Armazems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colunas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdRua = table.Column<long>(type: "bigint", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ordem = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colunas_Ruas_IdRua",
                        column: x => x.IdRua,
                        principalTable: "Ruas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nivel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdColuna = table.Column<long>(type: "bigint", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ordem = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nivel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nivel_Colunas_IdColuna",
                        column: x => x.IdColuna,
                        principalTable: "Colunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blocos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdNivel = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoFisico = table.Column<string>(type: "text", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Nome = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ordem = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blocos_Nivel_IdNivel",
                        column: x => x.IdNivel,
                        principalTable: "Nivel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blocos_IdNivel",
                table: "Blocos",
                column: "IdNivel");

            migrationBuilder.CreateIndex(
                name: "IX_Colunas_IdRua",
                table: "Colunas",
                column: "IdRua");

            migrationBuilder.CreateIndex(
                name: "IX_Nivel_IdColuna",
                table: "Nivel",
                column: "IdColuna");

            migrationBuilder.CreateIndex(
                name: "IX_Ruas_IdArmazem",
                table: "Ruas",
                column: "IdArmazem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocos");

            migrationBuilder.DropTable(
                name: "Nivel");

            migrationBuilder.DropTable(
                name: "Colunas");

            migrationBuilder.DropTable(
                name: "Ruas");
        }
    }
}

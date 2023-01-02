using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Niobe.Data.Migrations
{
    public partial class CriacaoContrato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeAbreviado = table.Column<string>(type: "text", nullable: true),
                    TipodeCliente = table.Column<string>(type: "text", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    CPF = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdFilial = table.Column<long>(type: "bigint", nullable: false),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    DatadoCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatadoContrato = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime", nullable: false),
                    DatadaProposta = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IdArmazem = table.Column<long>(type: "bigint", nullable: false),
                    DiaFaturamento = table.Column<int>(type: "int", nullable: false),
                    AliquotadoISS = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Serial = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Armazems_IdArmazem",
                        column: x => x.IdArmazem,
                        principalTable: "Armazems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Filiais_IdFilial",
                        column: x => x.IdFilial,
                        principalTable: "Filiais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    CEP = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    CaixaPostal = table.Column<string>(type: "text", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Cidade = table.Column<string>(type: "text", nullable: true),
                    IdContrato = table.Column<long>(type: "bigint", nullable: false),
                    IdCliente = table.Column<long>(type: "bigint", nullable: false),
                    Codigo = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enderecos_Contratos_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdArmazem",
                table: "Contratos",
                column: "IdArmazem");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdCliente",
                table: "Contratos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdFilial",
                table: "Contratos",
                column: "IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdCliente",
                table: "Enderecos",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_IdContrato",
                table: "Enderecos",
                column: "IdContrato",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

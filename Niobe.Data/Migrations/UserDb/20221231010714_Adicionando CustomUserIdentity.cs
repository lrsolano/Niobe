using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Niobe.Data.Migrations.UserDb
{
    public partial class AdicionandoCustomUserIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "a84e777c-af9c-495f-9b77-d7e86e90df2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "71767499-54b0-4968-826f-9e5d75f75076");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bb0eb314-ac5d-4c87-af2c-7129caa57fb4", "AQAAAAEAACcQAAAAEHA8OHvpdMTHY5KFA2NlecLatukBQcJopEPe6oCbmY9jw3RC6V/EATTIwSHPmsNg4g==", "b6d251ec-b9c5-47b7-b27b-7bccf940d25b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "bb3e5601-2562-485a-8469-b258536b5896");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8cbd2e5a-68a9-40e3-8fa9-587a89f57e55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2871a97-1c73-4df3-bb7f-8b50d515b0e1", "AQAAAAEAACcQAAAAEAP0D7wk6WTBBV4kef/c+nj645t4jG1t1lculGUCg04FN004qAC28mK3zZqp/PIgNg==", "1949c824-e665-41d7-ac75-459b9c2f4867" });
        }
    }
}

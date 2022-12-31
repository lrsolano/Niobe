using Microsoft.EntityFrameworkCore.Migrations;

namespace Niobe.Data.Migrations.UserDb
{
    public partial class RoleRegular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8cbd2e5a-68a9-40e3-8fa9-587a89f57e55", "manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "bb3e5601-2562-485a-8469-b258536b5896", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2871a97-1c73-4df3-bb7f-8b50d515b0e1", "AQAAAAEAACcQAAAAEAP0D7wk6WTBBV4kef/c+nj645t4jG1t1lculGUCg04FN004qAC28mK3zZqp/PIgNg==", "1949c824-e665-41d7-ac75-459b9c2f4867" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18fc0366-de24-49ad-9aca-068bc32dbdfe", "admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07199881-1b23-42d2-80f0-5150f523d3bf", "AQAAAAEAACcQAAAAEGDdA5Z6JoNTdHKKjNbLhi+1csh6wBrXZ40/omVENNtLGzE/CkX2Wnvodli7afAh+Q==", "d5124739-9f91-443b-b5ce-1d8683663534" });
        }
    }
}

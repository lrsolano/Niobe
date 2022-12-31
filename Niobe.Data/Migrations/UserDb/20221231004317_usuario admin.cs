using Microsoft.EntityFrameworkCore.Migrations;

namespace Niobe.Data.Migrations.UserDb
{
    public partial class usuarioadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99999, "18fc0366-de24-49ad-9aca-068bc32dbdfe", "manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 999999, 0, "07199881-1b23-42d2-80f0-5150f523d3bf", "admin@admin.com", true, false, null, "GOJO@GOJO.COM", "GOJO", "AQAAAAEAACcQAAAAEGDdA5Z6JoNTdHKKjNbLhi+1csh6wBrXZ40/omVENNtLGzE/CkX2Wnvodli7afAh+Q==", null, false, "d5124739-9f91-443b-b5ce-1d8683663534", false, "gojo" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 99999, 999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 99999, 999999 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 999999);
        }
    }
}

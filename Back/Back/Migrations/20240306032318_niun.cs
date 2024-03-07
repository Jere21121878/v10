using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back.Migrations
{
    public partial class niun : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1927fc21-61f9-44cf-91b6-bebf9d8a848e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d2b8507-91f2-4fd2-9e9c-06f082046aae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c974015-2edc-4d51-b264-4a35d91b8d78");

            migrationBuilder.AlterColumn<string>(
                name: "PlanoId",
                table: "Fotos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36e576fb-a4ac-4eef-b952-e3b789c5682c", "4fce1bbd-254c-47b2-8659-8f9674fb753d", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3a38560b-fa6f-4d3b-b4b7-b2834272af8a", "2cb52d4c-47ad-4dc6-94db-3c496a2efe56", "Tecnico", "TECNICO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d11a02c-6fcb-4c68-b861-5914f571f341", "82856e29-e7aa-479e-9151-bbfdfe497684", "Licenciado", "LICENCIADO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36e576fb-a4ac-4eef-b952-e3b789c5682c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a38560b-fa6f-4d3b-b4b7-b2834272af8a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d11a02c-6fcb-4c68-b861-5914f571f341");

            migrationBuilder.AlterColumn<int>(
                name: "PlanoId",
                table: "Fotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1927fc21-61f9-44cf-91b6-bebf9d8a848e", "b86b3138-c4cd-4ab7-a8a1-7f6c7902b09e", "Licenciado", "LICENCIADO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4d2b8507-91f2-4fd2-9e9c-06f082046aae", "d14589d2-bee7-4952-a4d9-ad8f009a3fae", "Tecnico", "TECNICO" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8c974015-2edc-4d51-b264-4a35d91b8d78", "f8ae2a8f-dc7e-4ce0-affc-704be695519d", "Admin", "ADMIN" });
        }
    }
}

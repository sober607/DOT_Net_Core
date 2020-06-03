using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class AddWordPartData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorldParts",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Asia" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

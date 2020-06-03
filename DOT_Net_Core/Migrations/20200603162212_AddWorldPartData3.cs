using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class AddWorldPartData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WorldParts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Australia" },
                    { 6, "America" },
                    { 3, "Africa" },
                    { 4, "Europe" },
                    { 5, "Antarctic" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorldParts",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class NewsModelAddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
    table: "News",
    columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
    values: new object[] { 0, "Humanity finally colonized the Mercury!!", "Some text", true, 3 });

            migrationBuilder.InsertData(
            table: "News",
            columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
            values: new object[] { 1, "Increase your lifespan by 10 years, every morning you need...", "Some text", true, 4 });

            migrationBuilder.InsertData(
table: "News",
columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
values: new object[] { 2, "Scientists estimed the time of the vaccine invension: it is a summer of 2021", "Some text", false, 5 });

            migrationBuilder.InsertData(
table: "News",
columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
values: new object[] { 3, "Ukraine reduces the cost of its obligations!", "Some text", false, 4 });

            migrationBuilder.InsertData(
table: "News",
columns: new[] { "Id", "Title", "Text", "IsFake", "AuthorId" },
values: new object[] { 4, "A species were discovered in Africa: it is blue legless cat", "Some text", true, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

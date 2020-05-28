using Microsoft.EntityFrameworkCore.Migrations;

namespace Infestation.Migrations
{
    public partial class Fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
             table: "Countries",
             columns: new[] { "Id", "Name", "Population", "SickCount", "DeadCount", "RecoveredCount", "Vaccine" },
             values: new object[] { 1, "Italy", 244500000, 1234234, 1111, 96130, false });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 8, "Mario", "Cassone", 69, true, "Male", 1});

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 9, "Jimmi", "Todeski", 43, false, "Female", 1 });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "Id", "FirstName", "LastName", "Age", "IsSick", "Gender", "CountryId" },
                values: new object[] { 10, "Lena", "Fumicheva", 25, true, "Female", 3 });

            
           

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

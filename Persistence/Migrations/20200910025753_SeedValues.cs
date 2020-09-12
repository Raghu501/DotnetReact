using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class SeedValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Value",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Value", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Raghu" });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Raghu1" });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Raghu2" });

            migrationBuilder.InsertData(
                table: "Value",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Raghu3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Value");
        }
    }
}

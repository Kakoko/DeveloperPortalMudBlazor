using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stango.Server.Migrations
{
    public partial class AddedDeveloperTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Company", "Email", "UserName" },
                values: new object[] { new Guid("5bf28ecc-382b-4313-b768-ebe98e171fe6"), "CodeUnparalled", "chiefscientist@code.com", "ChiefScientist" });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Company", "Email", "UserName" },
                values: new object[] { new Guid("b3f88f7f-4ae2-4453-9593-45573b9b5644"), "Microsoft", "codefather@code.com", "CodeFather" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Developers");
        }
    }
}

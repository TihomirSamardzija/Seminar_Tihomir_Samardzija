using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seminar_Tihomir_Samardzija.Data.Migrations
{
    public partial class DetailsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserViewModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdressViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserViewModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdressViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdressViewModel_ApplicationUserViewModel_ApplicationUserViewModelId",
                        column: x => x.ApplicationUserViewModelId,
                        principalTable: "ApplicationUserViewModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdressViewModel_ApplicationUserViewModelId",
                table: "AdressViewModel",
                column: "ApplicationUserViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdressViewModel");

            migrationBuilder.DropTable(
                name: "ApplicationUserViewModel");
        }
    }
}

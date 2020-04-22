using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PresentationApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Presentation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VideoToken = table.Column<string>(nullable: true),
                    CurrentSlide = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slide",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Picture = table.Column<byte[]>(nullable: true),
                    PresentationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slide", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slide_Presentation_PresentationId",
                        column: x => x.PresentationId,
                        principalTable: "Presentation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slide_PresentationId",
                table: "Slide",
                column: "PresentationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slide");

            migrationBuilder.DropTable(
                name: "Presentation");
        }
    }
}

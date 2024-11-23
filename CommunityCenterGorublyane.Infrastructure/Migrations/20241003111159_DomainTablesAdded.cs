using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class DomainTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Activity identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Activity title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Activity description"),
                    Contact = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "Activity contact"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Activity image")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                },
                comment: "Community center's activity");

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "News identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "News title"),
                    Content = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "News content"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "News image"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of publication")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Comment identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Author's comment"),
                    Text = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: false, comment: "Comment content"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Date of creation"),
                    NewsId = table.Column<int>(type: "int", nullable: false, comment: "News identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "News comment");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_NewsId",
                table: "Comments",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}

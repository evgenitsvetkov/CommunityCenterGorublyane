using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class CommentsAndNewsTweaked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "News",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Comments",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Comments",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                comment: "Author's user identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69c57b78-ce33-4610-8c7d-689ad9ad8bf8", "AQAAAAEAACcQAAAAEKsRIqwOarN99xCJt4xyfpKwJ2WhXpqbvWJZS+xo3ePoHAQ4SAxs6t0zpRCIjY+qrg==", "1807bbbb-e266-4808-b1e7-c4d823a71a04" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "924c06c1-9bd7-4e64-ad79-a360ef979220", "AQAAAAEAACcQAAAAECoroceqyGhAknf435xl1wg8LGgkUJh9xQKrbj5UvOW0YEgbcev3GkJO3vVlygjR8g==", "26b2b0a4-ee24-45db-b942-9f5264509c8c" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "News",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Comments",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Comments",
                newName: "Text");

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Author's comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fae82b4d-de76-4f51-b08e-0ef15618b5ab", "AQAAAAEAACcQAAAAEGoTPywKsE13bYcBIuBZFpy/fzWQxgvqnkArC/eXihXqrW5c4AisO3L4/zNl3tcZFg==", "937fb5ab-9312-48d0-a167-b78324637853" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8857f74e-ccc4-440d-8cc8-bb89df5e1a1b", "AQAAAAEAACcQAAAAED5eEaMm0H0HsM7OdX2qP/7mP/fIXtBhE6IjWsAAQRa/9P/ywT8PUkjBF9BEG5mzWw==", "69cafee9-1545-455c-88a6-a4cdb08f72a4" });
        }
    }
}

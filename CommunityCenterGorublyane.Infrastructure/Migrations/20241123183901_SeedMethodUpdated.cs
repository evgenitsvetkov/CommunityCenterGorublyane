using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class SeedMethodUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/gallery/image23.jpg");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/gallery/image24.jpg");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "/images/gallery/image21.jpg");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "/images/gallery/image22.jpg");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa16242f-220b-4247-9a6b-9aae9e82406d", "AQAAAAEAACcQAAAAEF9a5vgKS+p3RFVHXF1XsXhwqzf+49QuC74mxMkoAjE1bueOLNCiLGWMhcM5gBiAgA==", "32480f4e-4d0c-43a9-b5ef-c7b0e56f772e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50632dcf-96bc-4f4e-b611-13ba3029a0a9", "AQAAAAEAACcQAAAAEC7+9iRrmF5UP8cnkFWi+JY8SW+Q86PLRM5loL/F1dqgZavimQCXej49KnOi3ty1eg==", "83accf01-55e9-4816-b7bf-e3f192f94544" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "");

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
        }
    }
}

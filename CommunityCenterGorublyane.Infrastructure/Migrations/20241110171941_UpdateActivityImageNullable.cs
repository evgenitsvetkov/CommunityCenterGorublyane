using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class UpdateActivityImageNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: true,
                comment: "News image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "News image");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Activity image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Activity image");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "News image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "News image");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Activity image",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Activity image");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de132bef-2232-4f0d-9c8f-660fef74ac6f", "AQAAAAEAACcQAAAAELAtkZ02MqRqgVgaOBfxMnvlvs3vHQTCZVylIR/w2c/q3+RgdefDim8/H19nlqj9JQ==", "762b0011-d298-45a0-9007-7a4cbdca3449" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "066d2cd2-5f27-460c-a37c-fe0f2ce01805", "AQAAAAEAACcQAAAAEEf9LbP1UGgVq3AAFeXksuT6xjUAv+vM5dOnMnCHCiMxGrsie1pJaZQvc8V0bbJT3A==", "75f66662-ce7c-47f8-84d9-d28f729166b4" });
        }
    }
}

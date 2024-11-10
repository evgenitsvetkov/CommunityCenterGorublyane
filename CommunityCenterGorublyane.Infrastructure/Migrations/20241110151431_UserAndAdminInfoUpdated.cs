using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class UserAndAdminInfoUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de132bef-2232-4f0d-9c8f-660fef74ac6f", "GUEST@mail.com", "GUEST@mail.com", "AQAAAAEAACcQAAAAELAtkZ02MqRqgVgaOBfxMnvlvs3vHQTCZVylIR/w2c/q3+RgdefDim8/H19nlqj9JQ==", "762b0011-d298-45a0-9007-7a4cbdca3449" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "066d2cd2-5f27-460c-a37c-fe0f2ce01805", "ADMIN@mail.com", "ADMIN@mail.com", "AQAAAAEAACcQAAAAEEf9LbP1UGgVq3AAFeXksuT6xjUAv+vM5dOnMnCHCiMxGrsie1pJaZQvc8V0bbJT3A==", "75f66662-ce7c-47f8-84d9-d28f729166b4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7852f37a-621a-4174-8abd-2d093ef52a4f", "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEGfaZ1di8XptMS7LYgwzFxTeyp5ueU4NKLLH3WefMYECdbV9Bj5D1ES1u8hMcI8oMw==", "3192bf58-00bc-42ae-8880-8da9da71c03c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe910db7-bef2-4a9d-9ea1-2a2265a67f9e", "admin@mail.com", "admin@mail.com", "AQAAAAEAACcQAAAAEBvmIofEUWweaN4BCNBM86jB8UzEg623Q7TmpjUPswLPFth1C+Kzg+O7TvBhWUk7gg==", "4064336c-b2ff-4aaf-a8c2-893dc807ca02" });
        }
    }
}

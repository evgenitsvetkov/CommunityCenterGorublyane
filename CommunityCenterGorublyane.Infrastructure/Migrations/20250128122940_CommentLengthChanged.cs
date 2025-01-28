using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class CommentLengthChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Comment content",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Comment content");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Activity description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Activity description");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b80e5760-d9cb-48e7-9e2c-0121c43b3d0c", "AQAAAAEAACcQAAAAEEqurZwV7EyTtaYx+iDgpzZEjdJ0a+yB5KKwq6MdZCGkZWTiDyh0/XT3mcDy5LWo3A==", "acaf1ea0-0df1-430c-b334-844406d60a92" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "780e307c-2fc6-4723-9656-a0bfbdda4756", "AQAAAAEAACcQAAAAEE8WjBmPGq/TVYDKPnWxK3ILN48tAHcs85chm/Sr6za/yrahY9Qjlj5lPKA4fzwPSQ==", "75abf2ae-3cbb-45af-9d9a-43611cfa259d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Comment content",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Comment content");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Activity description",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Activity description");

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
    }
}

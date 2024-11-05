using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class ActivitiesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "News",
                comment: "Community center's news");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "News content",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "News content");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "Comment content",
                oldClrType: typeof(string),
                oldType: "nvarchar(1500)",
                oldMaxLength: 1500,
                oldComment: "Comment content");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "Activity description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Activity description");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Activities",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                comment: "Activity contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "Activity contact");

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Contact", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Илко Желязков - 089 671 0606; Ралица Петрова - 088 323 7501", "За деца: понеделник и сряда - от 17:30ч. до 18:15ч. За юноши: понеделник и сряда - от 18:30ч. до 19:30ч.", "", "Детски танцов състав - Петлица" },
                    { 2, "Ралица Иванова - 089 671 0606", "Вторник и четвъртък - от 18:30ч. до 19:30ч.", "", "Школа по народни танци - Петлица, за възрастни" },
                    { 3, "Полина Димитрова - 088 565 2332", "За деца от 7 до 14 години: петък - от 18:00ч.", "", "Народно пеене" },
                    { 4, "Биляна Малджиева - 087 779 5558", "За деца от 4 до 14 години: вторник и петък - от 17:00ч. до 18:00ч.", "", "Художествена гимнастика" },
                    { 5, "Юлиана Николова - 089 655 2834", "За деца от 4 до 14 години - със записване", "", "Уроци по рисуване" },
                    { 6, "Никол Николова - 088 355 7792", "За деца от 6 до 12 години - със записване", "", "Школа по пияно" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7852f37a-621a-4174-8abd-2d093ef52a4f", "AQAAAAEAACcQAAAAEGfaZ1di8XptMS7LYgwzFxTeyp5ueU4NKLLH3WefMYECdbV9Bj5D1ES1u8hMcI8oMw==", "3192bf58-00bc-42ae-8880-8da9da71c03c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe910db7-bef2-4a9d-9ea1-2a2265a67f9e", "AQAAAAEAACcQAAAAEBvmIofEUWweaN4BCNBM86jB8UzEg623Q7TmpjUPswLPFth1C+Kzg+O7TvBhWUk7gg==", "4064336c-b2ff-4aaf-a8c2-893dc807ca02" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterTable(
                name: "News",
                oldComment: "Community center's news");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "News",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "News content",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "News content");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(1500)",
                maxLength: 1500,
                nullable: false,
                comment: "Comment content",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "Comment content");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Activities",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Activity description",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "Activity description");

            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Activities",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "Activity contact",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "Activity contact");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afb6feae-024c-4ee3-9c3b-4601d4236655", "AQAAAAEAACcQAAAAEK9cZFG18YEHxwa0DJTMZg8m1PMh95874rSFwgvYOeHOIRcpE+TOBZv/i9HvuiRicw==", "51d73d20-dcc9-4b15-8b3a-2fdf00395d25" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8810bd7d-8f08-4386-85cf-7f9e0ac6bcbf", "AQAAAAEAACcQAAAAEGwFubXzgkLYWswYr/JJPXvBeSkLaz9h9Ciow3MPnEqNl94M+vSrQIFtMxLptDz8kw==", "02f65827-98b1-4d02-ad6b-580e2ba7ebb4" });
        }
    }
}

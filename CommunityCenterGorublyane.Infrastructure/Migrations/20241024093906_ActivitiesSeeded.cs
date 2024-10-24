using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityCenterGorublyane.Infrastructure.Migrations
{
    public partial class ActivitiesSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Contact", "Description", "ImageUrl", "Title" },
                values: new object[,]
                {
                    { 1, "Илко Желязков - 089 671 0606\r\nРалица Петрова - 088 323 7501", "- за деца: понеделник и сряда - от 17:30ч. до 18:15ч.\r\n- за юноши: понеделник и сряда - от 18:30ч. до 19:30ч.", "", "Детски танцов състав - Петлица" },
                    { 2, "Ралица Иванова - 089 671 0606", "Вторник и четвъртък - от 18:30ч. до 19:30ч.", "", "Школа по народни танци - Петлица, за възрастни" },
                    { 3, "Полина Димитрова - 088 565 2332", "За деца от 7 до 14 години: петък - от 18:00ч.", "", "Народно пеене" },
                    { 4, "Биляна Малджиева - 087 779 5558", "За деца от 4 до 14 години: вторник и петък - от 17:00ч. до 18:00ч.", "", "Художествена Гимнастика" },
                    { 5, "Юлиана Николова - 089 655 2834", "За деца от 4 до 14 години - със записване", "", "Уроци по рисуване" },
                    { 6, "Никол Николова - 088 355 7792", "За деца от 6 до 12години - със записване", "", "Школа по пияно" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d3fbcc8-4529-46f8-8fcd-9706993b3285", "AQAAAAEAACcQAAAAEFb8pOKLeK2qtqHBXXKsuz1uLc3GfNaLjchM25uo50qlOr4iFDK+9qzITH9fGfp3TQ==", "c2f10538-1b66-4afb-b989-24ac172ccf9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f387f0b7-381d-4558-9274-ba7c0c3f55b7", "AQAAAAEAACcQAAAAECuKGdDcMu0sYesw+Xa1kS9/Ds/wixKGvsV9IxHaM/vybLwGc2nQPZnGu24SFa8llw==", "7768499a-30a5-485f-9640-4345e4282098" });
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

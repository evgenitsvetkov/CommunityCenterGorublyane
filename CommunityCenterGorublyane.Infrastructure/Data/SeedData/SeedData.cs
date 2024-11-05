using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace CommunityCenterGorublyane.Infrastructure.Data.SeedData
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; }

        public IdentityUser GuestUser { get; set; }

        public Activity FirstActivity { get; set; }

        public Activity SecondActivity { get; set; }

        public Activity ThirdActivity { get; set; }

        public Activity FourthActivity { get; set; }

        public Activity FifthActivity { get; set; }

        public Activity SixthActivity { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedActivities();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AdminUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"
            };

            AdminUser.PasswordHash =
                hasher.HashPassword(AdminUser, "admin1233");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
                hasher.HashPassword(GuestUser, "guest1233");
        }

        private void SeedActivities()
        {
            FirstActivity = new Activity()
            {
                Id = 1,
                Title = "Детски танцов състав - Петлица",
                Description = "За деца: понеделник и сряда - от 17:30ч. до 18:15ч. За юноши: понеделник и сряда - от 18:30ч. до 19:30ч.",
                Contact = "Илко Желязков - 089 671 0606; Ралица Петрова - 088 323 7501",
                ImageUrl = ""
            };

            SecondActivity = new Activity()
            {
                Id = 2,
                Title = "Школа по народни танци - Петлица, за възрастни",
                Description = "Вторник и четвъртък - от 18:30ч. до 19:30ч.",
                Contact = "Ралица Иванова - 089 671 0606",
                ImageUrl = ""
            };

            ThirdActivity = new Activity()
            {
                Id = 3,
                Title = "Народно пеене",
                Description = "За деца от 7 до 14 години: петък - от 18:00ч.",
                Contact = "Полина Димитрова - 088 565 2332",
                ImageUrl = ""
            };

            FourthActivity = new Activity()
            {
                Id = 4,
                Title = "Художествена гимнастика",
                Description = "За деца от 4 до 14 години: вторник и петък - от 17:00ч. до 18:00ч.",
                Contact = "Биляна Малджиева - 087 779 5558",
                ImageUrl = ""
            };

            FifthActivity = new Activity()
            {
                Id = 5,
                Title = "Уроци по рисуване",
                Description = "За деца от 4 до 14 години - със записване",
                Contact = "Юлиана Николова - 089 655 2834",
                ImageUrl = ""
            };

            SixthActivity = new Activity()
            {
                Id = 6,
                Title = "Школа по пияно",
                Description = "За деца от 6 до 12 години - със записване",
                Contact = "Никол Николова - 088 355 7792",
                ImageUrl = ""
            };
        }
    }
}

using Microsoft.AspNetCore.Identity;

namespace CommunityCenterGorublyane.Infrastructure.Data.SeedData
{
    internal class SeedData
    {
        public IdentityUser AdminUser { get; set; }

        public IdentityUser GuestUser { get; set; }

        public SeedData()
        {
            SeedUsers();
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
    }
}

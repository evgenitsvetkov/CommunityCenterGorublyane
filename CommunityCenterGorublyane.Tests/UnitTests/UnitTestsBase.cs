using CommunityCenterGorublyane.Infrastructure.Data;
using CommunityCenterGorublyane.Infrastructure.Data.Common;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using CommunityCenterGorublyane.Tests.Mocks;
using Microsoft.AspNetCore.Identity;

namespace CommunityCenterGorublyane.Tests.UnitTests
{
    public class UnitTestsBase
    {
        protected CommunityCenterDbContext _data;
        protected IRepository _repository;

        [OneTimeSetUp]
        public void SetUpBase()
        {
            _data = DatabaseMock.Instance;
            _repository = new Repository(_data);
            SeedDatabase();
        }

        public IdentityUser AdminUser { get; private set; }

        public IdentityUser GuestUser { get; private set; }

        public Activity FirstActivity { get; private set; }

        public News FirstNews { get; private set; }

        private void SeedDatabase()
        {
            AdminUser = new IdentityUser()
            {
                Id = "AdminUserId",
                UserName = "adminuser@mail.com",
                Email = "adminuser@mail.com"
            };

            _data.Users.Add(AdminUser);

            GuestUser = new IdentityUser()
            {
                Id = "GuestUserId",
                UserName = "guestuser@mail.com",
                Email = "guestuser@mail.com"
            };

            _data.Users.Add(GuestUser);

            FirstActivity = new Activity()
            {
                Title = "First Test Activity",
                Description = "This is a test description. This is a test description. This is a test description.",
                Contact = "This is a test contacts. This is a test contacts. This is a test contacts.",
                ImageUrl = "https://images.unsplash.com/photo-1519052537078-e6302a4968d4?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGNhdHxlbnwwfHwwfHx8MA%3D%3D"
            };

            _data.Activities.Add(FirstActivity);

            FirstNews = new News()
            {
                Title = "First Test News",
                Content = "This is a test description. This is a test description. This is a test description.",
                CreatedAt = DateTime.Now,
                ImageUrl = "https://images.unsplash.com/photo-1519052537078-e6302a4968d4?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MTR8fGNhdHxlbnwwfHwwfHx8MA%3D%3D"
            };

            _data.News.Add(FirstNews);
            _data.SaveChanges();
        }

        [OneTimeTearDown]
        public void TearDownBase()
            => _data.Dispose();
    }
}

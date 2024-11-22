using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Services;

namespace CommunityCenterGorublyane.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService _userService;

        [OneTimeSetUp]
        public void SetUp()
            => _userService = new UserService(_repository);

        [Test]
        public async Task AllAsync_ShouldReturnCorrectUsers()
        {
            //Arrange

            //Act: invoke the service method

            var result = await _userService.AllAsync();

            //Assert the returned users' count is correct
            var usersCount = _data.Users.Count();

            var resultUsers = result.ToList();
            
            Assert.That(resultUsers.Count(), Is.EqualTo(usersCount));

            //Assert a returned user data is correct 
            var user = resultUsers.FirstOrDefault(u => u.Email == GuestUser.Email);
            
            Assert.IsNotNull(user);
        }
    }
}

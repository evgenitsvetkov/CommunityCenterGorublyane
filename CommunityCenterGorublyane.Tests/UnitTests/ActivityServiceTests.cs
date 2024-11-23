using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.Activity;
using CommunityCenterGorublyane.Core.Services;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Tests.UnitTests
{
    [TestFixture]
    public class ActivityServiceTests : UnitTestsBase
    {
        private IActivityService _activityService;

        [OneTimeSetUp]
        public void SetUp()
            => _activityService = new ActivityService(_repository);

        [Test]
        public async Task ActivityDetailsById_ShouldReturnCorrectActivityData()
        {
            //Arrange: get a valid activity id
            var activityId = FirstActivity.Id;

            //Act: invoke the service method with the valid id
            var result = await _activityService.ActivityDetailsByIdAsync(activityId);

            //Assert the returned result data is correct
            var activityInDb = await _data.Activities.FindAsync(activityId);
            Assert.That(result.Id, Is.EqualTo(activityInDb.Id));
            Assert.That(result.Title, Is.EqualTo(activityInDb.Title));
        }

        [Test]
        public async Task Create_ShouldCreateActivity()
        {
            //Arrange: get the activities current count
            var activitiesInDbBefore = await _data.Activities.CountAsync();

            //Arrange: create a new Activity variable with needed data
            var newActivity = new Activity()
            {
                Title = "New Activity",
                Description = "This is the description for the new activity",
                Contact = "This are the contacts for the new activity",
                ImageUrl = ""
            };

            var newActivityFormModel = new ActivityFormModel()
            {
                Title = "New Activity",
                Description = "This is the description for the new activity",
                Contact = "This are the contacts for the new activity",
                ImageUrl = ""
            };


            //Act: invoke the service method with the neccessary data
            var newActivityId = await _activityService.CreateAsync(
                newActivityFormModel);

            //Assert the activities' current count have increased by 1
            var activitiesInDbAfter = await _data.Activities.CountAsync();
            Assert.That(activitiesInDbAfter, Is.EqualTo(activitiesInDbBefore + 1));
            
            //Assert the new activity is created with correct data
            var newActivityInDb = await _data.Activities.FindAsync(newActivityId);
            Assert.That(newActivityInDb.Title, Is.EqualTo(newActivity.Title));
        }

        [Test]
        public async Task Edit_ShouldEditActivityCorrectly()
        {
            //Arrange: add a new activity to the database

            var activity = new Activity()
            {
                Title = "New Activity",
                Description = "This is the description for the new activity",
                Contact = "This are the contacts for the new activity",
                ImageUrl = ""
            };

            await _data.Activities.AddAsync(activity);
            await _data.SaveChangesAsync();

            //Arrange: change the contact
            var newActivityFormModel = new ActivityFormModel()
            {
                Title = "New Activity",
                Description = "This is the description for the new activity",
                Contact = "Changes: This is the changed contacts for the old activity",
                ImageUrl = ""
            };

            //Act: invoke the method with valid data and changed contact
            await _activityService.EditAsync(activity.Id, newActivityFormModel);

            //Assert the activity data in the database is correct 
            var editedActivityInDb = await _data.Activities.FindAsync(activity.Id);
            Assert.IsNotNull(editedActivityInDb);
            Assert.That(editedActivityInDb.Title, Is.EqualTo(activity.Title));
            Assert.That(editedActivityInDb.Contact, Is.EqualTo(activity.Contact));
        }

        [Test]
        public async Task Delete_ShouldDeleteActivitySuccessfully()
        {
            //Arrange: add a new activity to the database
            var activity = new Activity()
            {
                Title = "New Activity",
                Description = "This is the description for the new activity",
                Contact = "This are the contacts for the new activity",
                ImageUrl = ""
            };

            await _data.AddAsync(activity);
            await _data.SaveChangesAsync();

            //Arrange: get current activities' count
            var activitiesCountBefore = await _data.Activities.CountAsync();

            //Act: invoke the service method with valid id
            await _activityService.DeleteAsync(activity.Id);

            //Assert the returned activities' count has decreased by 1
            var activitiesCountAfter = await _data.Activities.CountAsync();
            Assert.That(activitiesCountAfter, Is.EqualTo(activitiesCountBefore - 1));

            //Assert the activity is not present in the db
            var activityInDb = await _data.Activities.FindAsync(activity.Id);
            Assert.IsNull(activityInDb);
        }

        [Test]
        public async Task Exists_ShouldReturnCorrectTrue_WithValidId()
        {
            //Arrange: get a valid activity id
            var activityId = FirstActivity.Id;

            //Act: invoke the service method with the valid id
            var result = await _activityService.ExistsAsync(activityId);
            
            //Assert the returned result is true
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Exists_ShouldReturnCorrectFalse_WithInvalidId()
        {
            //Arrange: invalid activity id
            var activityId = 300;

            //Act: invoke the service method with the invalid id
            var result = await _activityService.ExistsAsync(activityId);

            //Assert the returned invalidResult is false
            Assert.IsFalse(result);
        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm()
        {
            //Arrange
            //Act
            var result = await _activityService.AllAsync("First Test Activity");

            //Assert
            Assert.That(1, Is.EqualTo(result.TotalActivitiesCount));
            Assert.IsTrue(result.Activities.First().Id == 1);

        }

        [Test]
        public async Task Test_AllAsync_FiltersBySearchTerm_WithInvalidSearchTerm()
        {
            //Arrange
            //Act
            var resultTwo = await _activityService.AllAsync("NotAValidSearchTerm");

            //Assert
            Assert.That(0, Is.EqualTo(resultTwo.TotalActivitiesCount));
            Assert.IsEmpty(resultTwo.Activities);
        }

    }
}

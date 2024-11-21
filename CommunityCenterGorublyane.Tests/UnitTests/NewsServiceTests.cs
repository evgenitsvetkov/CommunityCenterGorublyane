using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.Activity;
using CommunityCenterGorublyane.Core.Models.News;
using CommunityCenterGorublyane.Core.Services;
using CommunityCenterGorublyane.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityCenterGorublyane.Tests.UnitTests
{
    [TestFixture]
    public class NewsServiceTests : UnitTestsBase
    {
        private INewsService _newsService;

        [OneTimeSetUp]
        public void SetUp()
            => _newsService = new NewsService(_repository);

        [Test]
        public async Task Exists_ShouldReturnCorrectTrue_WithValidId()
        {
            //Arrange: get a valid news id
            var newsId = FirstNews.Id;

            //Act: invoke the service method with the valid id
            var result = await _newsService.ExistsAsync(newsId);

            //Assert the returned result is true
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Delete_ShouldDeleteNewsSuccessfully()
        {
            //Arrange: add a new news to the database
            var news = new News()
            {
                Title = "Test News",
                Content = "This is the content of the biggest news",
                CreatedAt = DateTime.Now,
                ImageUrl = ""
            };

            await _data.AddAsync(news);
            await _data.SaveChangesAsync();

            //Arrange: get current news' count
            var newsCountBefore = await _data.News.CountAsync();

            //Act: invoke the service method with valid id
            await _newsService.DeleteAsync(news.Id);

            //Assert the returned news' count has decreased by 1
            var newsCountAfter = await _data.News.CountAsync();
            Assert.That(newsCountAfter, Is.EqualTo(newsCountBefore - 1));

            //Assert the news is not present in the db
            var newsInDb = await _data.News.FindAsync(news.Id);
            Assert.IsNull(newsInDb);
        }

        [Test]
        public async Task Edit_ShouldEditNewsCorrectly()
        {
            //Arrange: add a new news to the database

            var news = new News()
            {
                Title = "Test News",
                Content = "This is the content of the biggest news",
                CreatedAt = DateTime.Now,
                ImageUrl = ""
            };

            await _data.News.AddAsync(news);
            await _data.SaveChangesAsync();

            //Arrange: change the content
            var newsFormModel = new NewsFormModel()
            {
                Title = "Test News",
                Content = "Changes: This is the changed content of the news",
                CreatedAt = DateTime.Now,
                ImageUrl = ""
            };

            //Act: invoke the method with valid data and changed contact
            await _newsService.EditAsync(news.Id, newsFormModel);

            //Assert the news data in the database is correct 
            var editedNewsInDb = await _data.News.FindAsync(news.Id);
            Assert.IsNotNull(editedNewsInDb);
            Assert.That(editedNewsInDb.Title, Is.EqualTo(news.Title));
            Assert.That(editedNewsInDb.Content, Is.EqualTo(news.Content));
        }

        [Test]
        public async Task Create_ShouldCreateNews()
        {
            //Arrange: get the news current count
            var newsInDbBefore = await _data.News.CountAsync();

            //Arrange: create a news variable with needed data
            var news = new News()
            {
                Title = "Test News",
                Content = "This is the content of the biggest news",
                CreatedAt = DateTime.Now,
                ImageUrl = ""
            };

            var newsFormModel = new NewsFormModel()
            {
                Title = "Test News",
                Content = "This is the content of the biggest news",
                CreatedAt = DateTime.Now,
                ImageUrl = ""
            };

            //Act: invoke the service method with the neccessary data
            var newsId = await _newsService.CreateAsync(
                newsFormModel);

            //Assert the news' current count hav increased by 1
            var newsInDbAfter = await _data.News.CountAsync();
            Assert.That(newsInDbAfter, Is.EqualTo(newsInDbBefore + 1));

            //Assert the new news is created with correct data
            var newsInDb = await _data.News.FindAsync(newsId);
            Assert.That(newsInDb.Title, Is.EqualTo(news.Title));
        }

        [Test]
        public async Task NewsDetailsById_ShouldReturnCorrectNewsData()
        {
            //Arrange: get a valid news id
            var newsId = FirstNews.Id;

            //Act: invoke the service method with the valid id
            var result = await _newsService.NewsDetailsByIdAsync(newsId);

            //Assert the returned result data is correct
            var newsInDb = await _data.News.FindAsync(newsId);
            Assert.That(result.Id, Is.EqualTo(newsInDb.Id));
            Assert.That(result.Title, Is.EqualTo(newsInDb.Title));
        }
    }
}

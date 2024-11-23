using CommunityCenterGorublyane.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Tests.IntegrationTests
{
    public class HistoryControllerTests
    {
        private HistoryController historyController;

        [OneTimeSetUp]
        public void SetUp()
            => this.historyController = new HistoryController();

        [Test]
        public void Index_ShouldReturnCorrectView()
        {
            // Arrange

            // Act: invoke the controller method with valid data
            var result = this.historyController.Index();

            // Assert the returned result is not null
            Assert.IsNotNull(result);

            //Assert the returned result is a view
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}

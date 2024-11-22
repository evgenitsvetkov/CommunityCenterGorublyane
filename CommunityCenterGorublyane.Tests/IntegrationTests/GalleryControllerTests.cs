using CommunityCenterGorublyane.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Tests.IntegrationTests
{
    public class GalleryControllerTests
    {
        private GalleryController galleryController;

        [OneTimeSetUp]
        public void SetUp()
            => this.galleryController = new GalleryController();

        [Test]
        public void Index_ShouldReturnCorrectView()
        {
            // Arrange

            // Act: invoke the controller method with valid data
            var result = this.galleryController.Index();

            // Assert the returned result is not null
            Assert.IsNotNull(result);

            //Assert the returned result is a view
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}

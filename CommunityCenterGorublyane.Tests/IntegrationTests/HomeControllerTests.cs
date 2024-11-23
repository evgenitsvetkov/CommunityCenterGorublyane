﻿using CommunityCenterGorublyane.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Tests.IntegrationTests
{
    public class HomeControllerTests
    {
        private HomeController homeController;

        [OneTimeSetUp]
        public void SetUp()
            => this.homeController = new HomeController(null);

        [Test]
        public void Error_ShouldReturnCorrectView()
        {
            //Arange: assign a valid status code to a variable
            var statusCode = 500;
            //Act: invoke the controller method with valid data
            var result = this.homeController.Error(statusCode);

            //Assert the returned result is not null
            Assert.IsNotNull(result);

            //Assert the returned result is a view
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
        }
    }
}

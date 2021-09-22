using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;
using WebApi.Test.Comparers;

namespace WebApi.Test
{
    [TestClass]
    public class RestaurantsControllerTest
    {
        [TestMethod]
        public void GetAllRestaurantTest()
        {
            //A
            var restaurantsFromLogic = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = 1,
                    Name = "HorreoBurger",
                    Address = "General Rivera 3091",
                    Products = new List<Product>
                    {
                        new Product()
                        {
                            Id=1,
                            Name = "Grajera",
                            Price = 300
                        }
                    }
                }
            };
            var restaurantLogicMock = new Mock<IRestaurantLogic>(MockBehavior.Strict);
            restaurantLogicMock.Setup(businessLogic => businessLogic.GetAll()).Returns(restaurantsFromLogic);
            var restaurantsController = new RestaurantController(restaurantLogicMock.Object);

            //A
            IActionResult response = restaurantsController.GetAll();
            var responseOk = response as OkObjectResult;
            var restaurantsResponse = responseOk.Value as List<Restaurant>;

            //A
            restaurantLogicMock.VerifyAll();
            CollectionAssert.AreEqual(restaurantsFromLogic, restaurantsResponse, new RestaurantComparer());
        }

        [TestMethod]
        public void GetByIdRestaurantTest()
        {
            var restaurantFromLogic = new Restaurant
            {
                Id = 1,
                Name = "HorreoBurger",
                Address = "General Rivera 3091",
                Products = new List<Product>
                {
                    new Product
                    {
                        Id =1,
                        Name = "Grajera",
                        Price= 300
                    }
                }
            };
            var restaurantLogicMock = new Mock<IRestaurantLogic>(MockBehavior.Strict);
            restaurantLogicMock.Setup(restaurantLogic => restaurantLogic.GetById(It.IsAny<int>())).Returns(restaurantFromLogic);
            var restaurantController = new RestaurantController(restaurantLogicMock.Object);

            IActionResult response = restaurantController.GetById(1);
            var responseOk = response as OkObjectResult;
            var restaurantResponse = responseOk.Value as Restaurant;

            restaurantLogicMock.VerifyAll();
            Assert.AreEqual(0, new RestaurantComparer().Compare(restaurantFromLogic, restaurantResponse));
        }

        [TestMethod]
        public void CreateTest()
        {
            var restaurantToCreate = new Restaurant
            {
                Name = "HorreoBurger",
                Address = "General Rivera 3091"
            };
            var restaurantFromLogic = new Restaurant
            {
                Id = 1,
                Name = "HorreoBurger",
                Address = "General Rivera 3091",
            };
            var restaurantLogicMock = new Mock<IRestaurantLogic>(MockBehavior.Strict);
            restaurantLogicMock.Setup(restaurantLogic => restaurantLogic.Add(It.IsAny<Restaurant>())).Returns(restaurantFromLogic);
            var restaurantControlller = new RestaurantController(restaurantLogicMock.Object);

            IActionResult response = restaurantControlller.Create(restaurantToCreate);
            var responseCreated = response as ObjectResult;
            var restaurantResponse = responseCreated.Value as Restaurant;

            restaurantLogicMock.VerifyAll();
            Assert.AreEqual(0, new RestaurantComparer().Compare(restaurantFromLogic, restaurantResponse));
        }
    }
}

using System.Collections.Generic;
using BusinessLogicInterface;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApi.Controllers;

namespace WebApi.Test
{
    [TestClass]
    public class RestaurantsControllerTest
    {
        [TestMethod]
        public void GetAllRestaurantTest()
        {
            //A
            var restaurants = new List<Restaurant>()
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
                            Name = "Grajera",
                            Price = 300
                        }
                    }
                }
            };
            var restaurantLogicMock = new Mock<IRestaurantLogic>(MockBehavior.Strict);
            restaurantLogicMock.Setup(businessLogic => businessLogic.GetAll()).Returns(restaurants);
            RestaurantController restaurantsController = new RestaurantController(restaurantLogicMock.Object);

            //A
            IActionResult response = restaurantsController.Get();
            var responseOk = response as OkObjectResult;
            var restaurantsResponse = responseOk.Value as List<Restaurant>;

            //A
            restaurantLogicMock.VerifyAll();
            Assert.AreEqual(restaurants[0], restaurantsResponse[0]);
        }
    }
}

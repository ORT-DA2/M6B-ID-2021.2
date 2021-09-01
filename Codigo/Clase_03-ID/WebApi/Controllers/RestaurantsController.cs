using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicInterface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private static readonly List<Restaurant> restaurants = new List<Restaurant>()
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

        private readonly IBusinessLogic businessLogic;

        public RestaurantsController(IBusinessLogic businessLogic)
        {
            this.businessLogic = businessLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var restaurant = restaurants.FirstOrDefault((restaurant) => restaurant.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            restaurants.Add(restaurant);

            return Ok(restaurant);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Restaurant updatedRestaurant)
        {
            var restaurantToUpdate = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurantToUpdate == null)
            {
                return NotFound();
            }

            restaurantToUpdate.Address = updatedRestaurant.Address;

            return Ok(restaurantToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            restaurants.Remove(restaurant);

            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("restaurants")]
    public class RestaurantController : ControllerBase
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(restaurants);
        }

        [HttpGet("{restaurantId}", Name = "GetRestaurant")]
        public IActionResult GetById(int restaurantId)
        {
            var restaurant = restaurants.FirstOrDefault((restaurant) => restaurant.Id == restaurantId);

            if (restaurant == null)
            {
                return NotFound($"Not found Restaurant {restaurantId}");
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Count + 1;
            restaurants.Add(restaurant);

            return CreatedAtRoute("GetRestaurant", new { restaurantId = restaurant.Id }, restaurant);
        }

        [HttpPut("{restaurantId}")]
        public IActionResult Put(int restaurantId, Restaurant updatedRestaurant)
        {
            var restaurantSaved = restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);

            if (restaurantSaved is null)
            {
                return NotFound();
            }

            updatedRestaurant.Id = restaurantId;
            restaurantSaved = updatedRestaurant;

            return NoContent();
        }

        [HttpDelete("{restaurantId}")]
        public IActionResult Delete(int restaurantId)
        {
            var restaurant = restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);

            if (restaurant is null)
            {
                return NotFound();
            }

            restaurants.Remove(restaurant);

            return NoContent();
        }
    }
}

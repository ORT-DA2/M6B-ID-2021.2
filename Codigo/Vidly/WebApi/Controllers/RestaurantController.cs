using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicInterface;
using Domain;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantLogic _restaurantLogic;

        public RestaurantController(IRestaurantLogic restaurantLogic)
        {
            this._restaurantLogic = restaurantLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var restaurants = this._restaurantLogic.GetAll();

            return Ok(restaurants);
        }

        [HttpGet("{restaurantId}", Name = "GetRestaurant")]
        public IActionResult GetById(int restaurantId)
        {
            var restaurant = this._restaurantLogic.GetById(restaurantId);

            if (restaurant == null)
            {
                return NotFound($"Not found Restaurant {restaurantId}");
            }

            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post(Restaurant restaurant)
        {
            var newRestaurant = this._restaurantLogic.Add(restaurant);

            return CreatedAtRoute("GetRestaurant", new { restaurantId = newRestaurant.Id }, newRestaurant);
        }

        [HttpPut("{restaurantId}")]
        public IActionResult Put(int restaurantId, Restaurant updatedRestaurant)
        {
            try
            {
                this._restaurantLogic.Update(restaurantId, updatedRestaurant);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{restaurantId}")]
        public IActionResult Delete(int restaurantId)
        {
            try
            {
                this._restaurantLogic.Delete(restaurantId);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}

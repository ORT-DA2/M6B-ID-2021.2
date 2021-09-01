using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using Domain;

namespace BusinessLogic
{
    public class RestaurantLogic : IRestaurantLogic
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

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = restaurants.Count + 1;
            restaurants.Add(restaurant);

            return restaurant;
        }

        public void Delete(int restaurantId)
        {
            var restaurant = restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);

            if(restaurant is null)
            {
                throw new Exception("Not found restaurant");
            }

            restaurants.Remove(restaurant);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants;
        }

        public Restaurant GetById(int restaurantId)
        {
            var restaurant = restaurants.FirstOrDefault((restaurant) => restaurant.Id == restaurantId);

            return restaurant;
        }

        public void Update(int restaurantId, Restaurant restaurant)
        {
            var restaurantSaved = restaurants.FirstOrDefault(restaurant => restaurant.Id == restaurantId);

            if(restaurantSaved is null)
            {
                throw new Exception("Not found restaurant");
            }

            restaurant.Id = restaurantId;
            restaurantSaved = restaurant;
        }
    }
}

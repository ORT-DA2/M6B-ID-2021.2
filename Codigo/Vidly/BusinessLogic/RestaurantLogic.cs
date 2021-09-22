using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicInterface;
using BusinessLogicInterface.Exceptions;
using DataAccessInterface;
using Domain;

namespace BusinessLogic
{
    public class RestaurantLogic : IRestaurantLogic
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantLogic(IRestaurantRepository restaurantRepository)
        {
            this._restaurantRepository = restaurantRepository;
        }

        public Restaurant Add(Restaurant restaurant)
        {
            if(restaurant is null)
            {
                throw new ArgumentNullException("Restaurant can't be null");
            }

            restaurant.Validate();

            bool existRestaurant = this._restaurantRepository.Exist(restaurantSaved => restaurantSaved.Name == restaurant.Name);
            if(existRestaurant)
            {
                throw new DuplicatedRestaurantException(restaurant.Name);
            }

            this._restaurantRepository.Create(restaurant);

            return restaurant;
        }

        public void Delete(int restaurantId)
        {
            var restaurant = this._restaurantRepository.GetById(restaurantId);

            this._restaurantRepository.Delete(restaurant);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            IEnumerable<Restaurant> restaurants = this._restaurantRepository.GetAll();

            return restaurants;
        }

        public Restaurant GetById(int restaurantId)
        {
            Restaurant restaurant = this._restaurantRepository.GetById(restaurantId);

            return restaurant;
        }

        public void Update(int restaurantId, Restaurant restaurant)
        {
            bool existRestaurant = this._restaurantRepository.Exist(restaurantSaved => restaurantSaved.Id == restaurantId);
            if(!existRestaurant)
            {
                throw new ArgumentNullException("Restaurant not found"); 
            }

            restaurant.Id = restaurantId;
            this._restaurantRepository.UpdateAll(restaurant);
        }
    }
}

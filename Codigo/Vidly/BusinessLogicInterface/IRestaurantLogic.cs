using System.Collections.Generic;
using Domain;

namespace BusinessLogicInterface
{
    public interface IRestaurantLogic
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int restaurantId);
        Restaurant Add(Restaurant restaurant);
        void Update(int restaurantId, Restaurant restaurant);
        void Delete(int restaurantId);
    }
}
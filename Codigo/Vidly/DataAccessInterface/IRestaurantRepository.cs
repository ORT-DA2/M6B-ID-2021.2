using System.Collections.Generic;
using Domain;

namespace DataAccessInterface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        Restaurant Create(Restaurant restaurant);
        void Update(int id, Restaurant restaurant);
        void Delete(int id);
    }
}
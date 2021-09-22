using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain;

namespace DataAccessInterface
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Create(Restaurant restaurant);
        void UpdateAll(Restaurant restaurant);
        void Delete(Restaurant restaurant);
    }
}
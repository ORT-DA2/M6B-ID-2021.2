using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain;

namespace DataAccessInterface
{
    public interface IRestaurantRepository
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant GetById(int id);
        Restaurant Create(Restaurant restaurant);
        void UpdateAll(Restaurant restaurant);
        void Delete(Restaurant restaurant);
        bool Exist(Expression<Func<Restaurant, bool>> expression);
    }
}
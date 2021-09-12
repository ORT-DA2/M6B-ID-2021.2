using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccessInterface;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DbSet<Restaurant> _restaurants;
        private readonly DbContext _context;

        public RestaurantRepository(DbContext context)
        {
            this._context = context;
            this._restaurants = context.Set<Restaurant>();
        }

        public Restaurant Create(Restaurant restaurant)
        {
            if(restaurant is null)
            {
                throw new ArgumentNullException("Restaurant can't be null");
            }
            
            this._restaurants.Add(restaurant);
            this._context.SaveChanges();

            return restaurant;
        }

        public void Delete(Restaurant restaurant)
        {
            this._restaurants.Remove(restaurant);

            this._context.SaveChanges();
        }

        public bool Exist(Expression<Func<Restaurant, bool>> expression)
        {
            bool existRestaurant = this._restaurants.Any(expression);

            return existRestaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this._restaurants;
        }

        public Restaurant GetById(int id)
        {
            Restaurant restaurant = this._restaurants.First(restaurant => restaurant.Id == id);

            return restaurant;
        }

        public void UpdateAll(Restaurant restaurant)
        {
            if(restaurant is null)
            {
                throw new ArgumentNullException("Restaurant can't be null");
            }

            this._restaurants.Update(restaurant);
            this._context.SaveChanges();
        }
    }
}
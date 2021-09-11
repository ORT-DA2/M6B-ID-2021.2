using System.Collections.Generic;
using System.Linq;
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
            this._restaurants.Add(restaurant);
            this._context.SaveChanges();

            return restaurant;
        }

        public void Delete(int id)
        {
            var restaurantToDelete = this._restaurants.First(restaurant => restaurant.Id == id);
            this._context.Entry<Restaurant>(restaurantToDelete).State = EntityState.Deleted;

            this._context.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return this._restaurants;
        }

        public Restaurant GetById(int id)
        {
            Restaurant restaurant = this._restaurants.FirstOrDefault(restaurant => restaurant.Id == id);

            return restaurant;
        }

        public void Update(int id, Restaurant restaurant)
        {
            Restaurant restaurantToUpdate = this._restaurants.FirstOrDefault(restaurant => restaurant.Id == id);

            restaurantToUpdate = restaurant;
            restaurantToUpdate.Id = id;

            this._context.Entry<Restaurant>(restaurantToUpdate).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}
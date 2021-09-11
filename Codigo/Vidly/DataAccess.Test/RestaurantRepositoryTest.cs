using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Test.Comparers;

namespace DataAccess.Test
{
    [TestClass]
    public class RestaurantRepositoryTest
    {
        private readonly DbConnection _connection;
        private readonly RestaurantRepository _restaurantRepository;
        private readonly VidlyContext _vidlyContext;

        public RestaurantRepositoryTest()
        {
            this._connection = new SqliteConnection("Filename=:memory:");
            this._vidlyContext = new VidlyContext(new DbContextOptionsBuilder<VidlyContext>().UseSqlite(this._connection).Options);
            this._restaurantRepository = new RestaurantRepository(this._vidlyContext);
        }

        [TestInitialize]
        public void Setup()
        {
            this._connection.Open();
            this._vidlyContext.Database.EnsureCreated();
        }

        [TestCleanup]
        public void CleanUp()
        {
            this._vidlyContext.Database.EnsureDeleted();
        }

        [TestMethod]
        public void GetAllRestaurantsTest()
        {
            var restaurantsExpected = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = 1,
                    Name = "a",
                    Address = "a"
                }
            };
            this._vidlyContext.Add(new Restaurant
            {
                Id = 1,
                Name = "a",
                Address="a"
            });
            this._vidlyContext.SaveChanges();
            List<Restaurant> restaurantsDataBase = this._restaurantRepository.GetAll().ToList();

            Assert.AreEqual(1, restaurantsDataBase.Count());
            CollectionAssert.AreEqual(restaurantsExpected, restaurantsDataBase, new RestaurantComparer());
        }
    }
}
